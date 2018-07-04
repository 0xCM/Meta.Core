//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;

    
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using Meta.Core;

    using SqlT.Models;
    using SqlT.Language;
    using SqlT.Core;
    using SqlT.Services;

    using static metacore;
    using sigX = SignatureCalculator;

    class SignatureTokenizer
    {
        int lineCount = 0;
        Dictionary<string, (int lineNumber, int occurences)> counts;
        MutableSet<TSql.TSqlFragment> consumed;
        int currentLevel = 0;

        Action<TSql.TSqlFragment> ConsumationObserver { get; }


        F consume<F>(F tSql)
            where F : TSql.TSqlFragment
        {
            consumed.Add(tSql);

            ConsumationObserver?.Invoke(tSql);

            if (tSql is TSql.MultiPartIdentifier)
            {
                foreach (var part in (tSql as TSql.MultiPartIdentifier).Identifiers)
                    consume(part);
            }
            return tSql;
        }

       
        string block(string content, bool embrace = true)
            => SyntaxBlockFormatter.FormatBlock(currentLevel, content, embrace);

        FragmentAssignment tokenize_fragment_assignment(ClrProperty property, FragmentToken value)
            => new FragmentAssignment(property, value, currentLevel);

        CollectionAssignment tokenize_collection_assignment(ClrProperty property, FragmentTokens tokens)
            => new CollectionAssignment(property, tokens, currentLevel);


        FragmentTokens tokenize_fragments(IEnumerable<TSql.TSqlFragment> fragments)
            => fragments.Select(tokenize_fragment).ToArray();

        ScalarAssignment tokenize_scalar_assignment(ClrProperty property, object value)
            => new ScalarAssignment(property, value, currentLevel);

        CollectionAssignment tokenize_collection_assignment(ClrProperty property, IEnumerable<TSql.TSqlFragment> fragments)
        {
            var fragment_tokens = tokenize_fragments(fragments);
            var token = tokenize_collection_assignment(property, fragment_tokens);
            return token;
        }

        FragmentToken tokenize_fragment(TSql.TSqlFragment fragment)
            => new FragmentToken(fragment, TokenizeAny(consume(fragment)), currentLevel);


        IEnumerable<(ClrProperty property, object value)> GetFragmentScalarValues(TSql.TSqlFragment tSql)
            =>
            from 
                p in tSql.DomProperties()
            where
              p.PropertyType.IsEnumType
              || p.PropertyType.IsPrimitive
              || p.PropertyType == typeof(string)
            let eval = new SignaturePropertyValue(p, p.GetValue(tSql))
            where
                eval.SupressValue() == SyntaxSuppression.Show
            select 
                (p, p.GetValue(tSql));

        IEnumerable<(ClrProperty property, TSql.TSqlFragment fragment)> GetFragmentPropertyValues(TSql.TSqlFragment tSql)
        {
            var values = 
                from p in tSql.GetType().GetPublicProperties(true)
                where p.PropertyType.IsSubclassOf(typeof(TSql.TSqlFragment))
                let v = p.GetValue(tSql) as TSql.TSqlFragment
                where v != null
                select (ClrProperty.Get(p), v);
            
            foreach(var v in values)
                yield return v;

         }

        IEnumerable<(ClrProperty property, IEnumerable<TSql.TSqlFragment> collection)> GetFragmentCollectionValues(TSql.TSqlFragment tSql)
        {

            var props = rolist(ClrClass.Get(tSql.GetType()).PublicInstanceProperties);

            var genericListProps = rolist
                (from p in props
                where p.PropertyType.IsGenericEnumerableType
                select p);

            var values = 
                from p in genericListProps
                let typeArg =  p.PropertyType.GenericTypeArguments.Single()
                where typeArg.ReflectedElement.IsSubclassOf(typeof(TSql.TSqlFragment))
                let v = p.GetValue(tSql) as IEnumerable
                where v != null
                select (p,v);

            foreach (var cv in values)
                yield return(cv.Item1, cv.v.Cast<TSql.TSqlFragment>());
                
        }

        IEnumerable<SignatureToken> TokenizeMemberFragements(TSql.TSqlFragment tSql)
        {           

            var fragScalarValues = GetFragmentScalarValues(tSql).ToList();
            foreach (var fp in fragScalarValues)
            {
                if (isNotBlank(toString(fp.value)))
                {
                    var tokenization = tokenize_scalar_assignment(fp.property, $"{fp.value}");
                    yield return tokenization;
                }
            }

            var fragPropertyValues = GetFragmentPropertyValues(tSql).ToList();
            foreach (var fp in fragPropertyValues)
            {
                var tokenization = tokenize_fragment_assignment(fp.property, tokenize_fragment(fp.fragment));
                yield return tokenization;
            }


            var fragCollectionValues = GetFragmentCollectionValues(tSql).ToList();
            foreach (var fcv in fragCollectionValues)
            {
                var cv = fcv.collection.ToList();
                if (!cv.Any())
                    continue;

                var tokenization = tokenize_collection_assignment(fcv.property, cv);
                yield return tokenization;
            }
            
        }


        Option<SignatureToken> TryTokenize(TSql.Literal tSql)
            => ifNotNull(tSql, 
                _ => new LiteralToken(currentLevel, tSql.LiteralType, consume(tSql).Value), 
                () => null);
        

        Option<SignatureToken> TryTokenize(TSql.Identifier tSql)
            => ifNotNull(tSql, 
                _ => new IdentifierToken(currentLevel, consume(tSql).Value, tSql.QuoteType), 
                () => null);


        Option<SignatureToken> TryTokenize(TSql.ValueExpression tSql)
            => ifNotNull(tSql, 
                _ => new ValueExpressionToken(currentLevel, tSql.GetFragmentText()), 
                () => null);

        Option<SignatureToken> TryTokenize(TSql.IdentifierOrValueExpression tSql)
        {
            if (isNull(tSql))
                return null;

            return isNotNull(tSql.Identifier)
                ? TryTokenize(consume(tSql.Identifier))
                : TryTokenize(consume(tSql.ValueExpression));
        }        

        Option<SignatureToken> TryTokenize(TSql.MultiPartIdentifier tSql)
        {
            if (isNull(tSql) || tSql.Count == 0)
                return null;

            if (tSql.Count == 1)
                return TryTokenize(consume(tSql[0]));
            else
            {
                var identifiers = map(consume(tSql).Identifiers, 
                    id => TryTokenize(id))
                        .Where(x => x.IsSome())
                        .Select(x => x.ValueOrDefault())
                        .Cast<IdentifierToken>();

                return new CompositeIdentifierToken(identifiers);                        

            }
        }

        string Tokenize(TSql.Literal tSql)
            => TryTokenize(tSql).MapValueOrDefault(v => $"{v}", string.Empty);

        string Tokenize(TSql.Identifier tSql)
            => TryTokenize(tSql).MapValueOrDefault(v => $"{v}", string.Empty);

        string Tokenize(TSql.ValueExpression tSql)
            => TryTokenize(tSql).MapValueOrDefault(v => $"{v}", string.Empty);


        string Tokenize(TSql.IdentifierOrValueExpression tSql)
        {
            if (isNull(tSql))
                return null;

            return isNotNull(tSql.Identifier)
                ? Tokenize(consume(tSql.Identifier))
                : Tokenize(consume(tSql.ValueExpression));

        }

        string Tokenize(TSql.MultiPartIdentifier tSql)
        {
            var attempt = TryTokenize(tSql);
            if (attempt)
            {
                var token = attempt.ValueOrDefault();
                switch(token)
                {
                    case CompositeIdentifierToken t:
                        return cast<CompositeIdentifierToken>(t).Format();
                    case IdentifierToken t:
                        return cast<IdentifierToken>(t).Format();
                }
            }
            return string.Empty;
        }
                


        string Tokenize(TSql.SchemaObjectName tSql)
             => ifNull(tSql, sigX.getNothing, 
                 _ => $"{tSql.TokenName()}{sigX.Paren(consume(tSql).ToObjectName())}");

        string Tokenize(TSql.TSqlFragment tSql)
        {
            if (tSql == null)
                return sigX.nothing;

            currentLevel++;

            var tokenizations = TokenizeMemberFragements(consume(tSql));
            var frags = string.Join(" ", tokenizations);            
            var result = $"{tSql.TokenName()}{block(frags)}";

            currentLevel--;

            return result;
        }



        string TokenizeAny(dynamic tSql)
        {
            if (isNull(tSql))
                return sigX.getNothing();

            return Tokenize(tSql);

        }


        public SignatureTokenizer()
        {
            counts = new Dictionary<string, (int,int)>();
            consumed = new MutableSet<TSql.TSqlFragment>();
        }

        public (SqlSyntaxSignature sig, IReadOnlySet<TSql.TSqlFragment> consumed) 
            CalcSignature(ParsedSqlFragment ParsedFragment)
        {
            var tSql = ParsedFragment.SqlFragment;
            var tokenValue =   TokenizeAny(ParsedFragment.SqlFragment);
            var current = tSql.TokenName();
            lineCount++;
            var last = counts.TryFind(current);
            last.OnSome(x => counts[current] = (lineCount, ++x.occurences))
                .OnNone(() => counts[current] = (lineCount, 1));

            return (new SqlSyntaxSignature(ParsedFragment.SqlScript, tSql.TokenName(), tokenValue), consumed);
        }
    }



}