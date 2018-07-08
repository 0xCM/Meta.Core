//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;

    using Modules;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    using static metacore;

    [UT.TestClass, UT.TestCategory("workflow/choice")]

    public class ChoiceTest
    {
        public enum Pick
        {
            A,
            B,
            C,
            D,
            E,
            F
        }

        [UT.TestMethod]
        public void Test01()
        {
            var initial = ChoiceIdentity.Identify(("1", "B"));
            var projection = initial.ToString();
            var inversion = ChoiceIdentity.Parse(projection);
            claim.equal(initial, inversion);


        }

        [UT.TestMethod]
        public void Test02()
        {
            var initial = new Choice(("1", "B"), "One");
            var projection = initial.ToString();
            var inversion = Choice.Parse(projection);
            claim.equal(initial, inversion);


        }

        [UT.TestMethod]
        public void Test05()
        {

            var choices = new Choices(("MyChoices", "A"),
                Seq.cons(
                    new Choice(("1", "B"), "One"),
                    new Choice(("2", "B"), "Two"),
                    new Choice(("3", "B"), "Three")
                    ));
            var text = choices.ToString();
            var back = Choices.Parse(text);

            claim.equal(choices, back);

        }


        [UT.TestMethod]
        public void Test10()
        {
            var choices = Choices.FromEnum<Pick>();
            claim.count(ClrEnum.Get<Pick>().Literals.Count, choices.Stream());

        }

        [UT.TestMethod]
        public void Test15()
        {
            var choice = Choice<int>.Parse("x : int => 3");
            claim.equal(3, choice.Map(x => x.Value));
        }


        [UT.TestMethod]
        public void Test20()
        {

            var @class = typeof(Pick).Name;

            Option<Choice> ChoiceFunction(Choice input)
            {

                switch (input.Value)
                {
                    case "A":
                        return new Choice(("B", @class), "B");
                    case "B":
                        return new Choice(("C", @class), "C");
                    case "C":
                        return new Choice(("D", @class), "D");
                    case "D":
                        return new Choice(("E", @class), "E");
                    case "E":
                        return none<Choice>(inform("Endstate"));
                    default:
                        return none<Choice>(error("Unmatched"));
                }
            }

            var wf = new Chooser(ChoiceFunction);
            var transitions = wf.Execute(new Choice(("A", @class), "A"));
        }


        [UT.TestMethod]
        public void Test25()
        {
            var @class = typeof(Pick);

            Option<Pick> ChoiceFunction(Pick input)
            {

                switch (input)
                {
                    case Pick.A:
                        return Pick.B;
                    case Pick.B:
                        return Pick.C;
                    case Pick.C:
                        return Pick.D;
                    case Pick.D:
                        return Pick.E;
                    case Pick.E:
                        return none<Pick>(inform("Endstate"));
                    default:
                        return none<Pick>(error("Unmatched"));
                }
            }
            var wf = new EnumChooser<Pick>(ChoiceFunction);
            var transitions = wf.Execute(new EnumChoice<Pick>(Pick.A));
            //claim.equal(List.cons(Pick.B, Pick.C, Pick.D, Pick.E), transitions);
        }
    }
}