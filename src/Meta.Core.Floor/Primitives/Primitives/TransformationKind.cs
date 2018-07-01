//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// Classifies a transformation
    /// </summary>
    public enum TransformationKind :  byte
    {
        Unclassified = 0,

        /// <summary>
        /// A function F:X->X such that F(x) = x ∀ x in X
        /// </summary>
        Identity= 1,

        /// <summary>
        /// A function F:X->Y where Y ⊆ X such that F(x) = x ∀ x in Y
        /// </summary>
        /// <remarks>
        /// If X = Y,  then the filter reduces to <see cref="Identity"/>. A filter does not
        /// alter any of carried points; it is an inclusion function in
        /// set-theoritic terms. In terms of SQL, it is represented by the criteria in
        /// a WHERE clause
        /// </remarks>
        Filter,
        
        /// <summary>
        /// A function F:X -> Y defined from an n-dimensional space X to an m-dimensional 
        /// subspace Y of X where n ≤ m and F(x₁,x₂,...,xₙ) = (x₁,x₂,...,xₘ) for all points
        /// (x₁,x₂,...,xₙ) in X
        /// </summary>
        /// <remarks>
        /// An embedding, like a filter, does not change any of the values that pass through it but
        /// unlike a filter, only *selected* axes of X are allowed to pass. In terms of SQL,
        /// it is analagous to the columns chosen from a table in a select statement and possibly
        /// transformed to suit the codomain.
        /// </remarks>
        Embedding,
        
        /// <summary>
        /// A function F:X -> X that satisfies the criteria for an embedding and
        /// an identify function when restricted to the embedded subspace
        /// </summary>
        /// <remarks>
        /// The behavior is exactly that of an embedding in which no transformations occur;
        /// the effect is merely a dimensionality reduction
        /// </remarks>
        Selector,

        /// <summary>
        /// A function F:X->Y between spaces X and Y of finite and equal dimension
        /// </summary>
        /// <remarks>
        /// This is inpired by the well-known proof in linear algebra that shows two
        /// vector spaces of finite dimensions m and n are isomorphic if and only if 
        /// m=n. A "morphism" in this context is not necessarily an isomorphism but
        /// may be depending on its characteristics. Morphism here is not a great
        /// term, but will do.
        /// </remarks>
        Morphism,
    
        /// <summary>
        /// An invertible bijection F:X->Y between spaces X and Y of finite and equal dimension
        /// </summary>
        Isomorphism,

        /// <summary>
        /// A function F:X -> Y₁⨯Y₂⨯...⨯Yₘ defined on the product space 
        /// X = X₁⨯X₂⨯...⨯Xₙ to the product space Y = Y₁⨯Y₂⨯...⨯Yₘ where each
        /// space Xₖ, Yₖ is of arbitrary finite dimension
        /// </summary>
        /// <remarks>
        /// A join can be expressed as a composition of filters and selectors
        /// </remarks>
        Join,

        /// <summary>
        /// F:X⨯Y -> Z
        /// </summary>
        Merge,

    }


}
