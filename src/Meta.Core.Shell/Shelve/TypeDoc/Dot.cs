//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;

    public static class Dot
    {
        public enum direction
        {
            [Label("")] none = 0,
            [Label("n")] north,
            [Label("ne")] north_east,
            [Label("e")] east,
            [Label("se")] south_east,
            [Label("s")] south,
            [Label("sw")] south_west,
            [Label("w")] west,
            [Label("nw")] north_west,
            [Label("c")] c
        }

        public abstract class element
        {

        }

        public abstract class statement<t> : element<t>
            where t: statement<t>,new()
        {


        }

        public sealed class statement : statement<statement>
        {


        }

        public abstract class element<t> : element
            where t : element<t>, new()
        {

        }

        public abstract class @operator<t> : element<t>
            where t: @operator<t>,new()
        {

        }

        public abstract class arrow<t> : @operator<t>
            where t : arrow<t>,new()
        {


        }
            
        public sealed class arrow : arrow<arrow>
        {

        }


        public abstract class node<t> : element<t>
            where t : node<t>, new()
        {

        }


        public sealed class node : node<node>
        {
            public node()
            {

            }
        }

        public abstract class edge<t> : element<t>
            where t : edge<t>, new()
        {

        }

        public sealed class edge : node<edge>
        {
            public edge()
            {

            }
        }

        public abstract class graph<t> : element<t>
            where t : graph<t>, new()
        {

        }

        public sealed class graph : graph<graph>
        {


        }

        public abstract class digraph<t> : graph<t>
            where t : digraph<t>,new()
        {

        }


        public sealed class digraph : digraph<digraph>
        {

        }

    }


}