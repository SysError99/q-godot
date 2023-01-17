using Godot;
using System.Collections.Generic;

namespace SysError99
{
    public class QGodotSharp : Node
    {
        private const string _QueryNames = "#QN";
        private const string _RegisteredScene = "#RS";
        private const string _UnregisteredScene = "registered_scene";

        private static Viewport Root;
        private static SceneTree MainTree;
        private static QGodotSharp Self;
        private static Dictionary<string, List<QueryObject0>> Queries0 = new();
        private static Dictionary<string, List<QueryObject1>> Queries1 = new();
        private static Dictionary<string, List<QueryObject2>> Queries2 = new();
        private static Dictionary<string, List<QueryObject3>> Queries3 = new();
        private static Dictionary<string, List<QueryObject4>> Queries4 = new();
        private static Dictionary<string, List<QueryObject5>> Queries5 = new();
        private static Dictionary<string, List<QueryObject6>> Queries6 = new();
        private static Dictionary<string, List<QueryObject7>> Queries7 = new();
        private static Dictionary<string, List<QueryObject8>> Queries8 = new();
        private static Dictionary<string, List<QueryObject9>> Queries9 = new();
        private static Dictionary<string, List<QueryObject10>> Queries10 = new();
        private static Dictionary<string, List<QueryObject11>> Queries11 = new();
        private static Dictionary<string, List<QueryObject12>> Queries12 = new();
        private static Dictionary<string, List<QueryObject13>> Queries13 = new();
        private static Dictionary<string, List<QueryObject14>> Queries14 = new();
        private static Dictionary<string, List<QueryObject15>> Queries15 = new();
        private static Dictionary<string, List<QueryObject16>> Queries16 = new();
        private static Dictionary<string, List<string>> Templates = new();

        #region Query

        public static IEnumerable<T> Query<T>()
            where T : Object
        {
            var queryName =  typeof(T).Name;
            if (Queries0.ContainsKey(queryName))
            {
                foreach (var obj in Queries0[queryName])
                    yield return obj.Get<T>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T).Name,
                    }
                );
                foreach (var obj in Query<T>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1)> Query<T0, T1>()
            where T0 : Object
            where T1 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name
            ;
            if (Queries1.ContainsKey(queryName))
            {
                foreach (var obj in Queries1[queryName])
                    yield return obj.Get<T0, T1>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                    }
                );
                foreach (var obj in Query<T0, T1>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2)> Query<T0, T1, T2>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name
            ;
            if (Queries2.ContainsKey(queryName))
            {
                foreach (var obj in Queries2[queryName])
                    yield return obj.Get<T0, T1, T2>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3)> Query<T0, T1, T2, T3>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name
            ;
            if (Queries3.ContainsKey(queryName))
            {
                foreach (var obj in Queries3[queryName])
                    yield return obj.Get<T0, T1, T2, T3>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4)> Query<T0, T1, T2, T3, T4>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name
            ;
            if (Queries4.ContainsKey(queryName))
            {
                foreach (var obj in Queries4[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5)> Query<T0, T1, T2, T3, T4, T5>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name
            ;
            if (Queries5.ContainsKey(queryName))
            {
                foreach (var obj in Queries5[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6)> Query<T0, T1, T2, T3, T4, T5, T6>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name
            ;
            if (Queries6.ContainsKey(queryName))
            {
                foreach (var obj in Queries6[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7)> Query<T0, T1, T2, T3, T4, T5, T6, T7>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name +
                typeof(T7).Name
            ;
            if (Queries7.ContainsKey(queryName))
            {
                foreach (var obj in Queries7[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6, T7>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                        typeof(T7).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6, T7>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name +
                typeof(T7).Name +
                typeof(T8).Name
            ;
            if (Queries8.ContainsKey(queryName))
            {
                foreach (var obj in Queries8[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                        typeof(T7).Name,
                        typeof(T8).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6, T7, T8>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name +
                typeof(T7).Name +
                typeof(T8).Name +
                typeof(T9).Name
            ;
            if (Queries9.ContainsKey(queryName))
            {
                foreach (var obj in Queries9[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                        typeof(T7).Name,
                        typeof(T8).Name,
                        typeof(T9).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name +
                typeof(T7).Name +
                typeof(T8).Name +
                typeof(T9).Name +
                typeof(T10).Name
            ;
            if (Queries10.ContainsKey(queryName))
            {
                foreach (var obj in Queries10[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                        typeof(T7).Name,
                        typeof(T8).Name,
                        typeof(T9).Name,
                        typeof(T10).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name +
                typeof(T7).Name +
                typeof(T8).Name +
                typeof(T9).Name +
                typeof(T10).Name +
                typeof(T11).Name
            ;
            if (Queries11.ContainsKey(queryName))
            {
                foreach (var obj in Queries11[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                        typeof(T7).Name,
                        typeof(T8).Name,
                        typeof(T9).Name,
                        typeof(T10).Name,
                        typeof(T11).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            where T12 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name +
                typeof(T7).Name +
                typeof(T8).Name +
                typeof(T9).Name +
                typeof(T10).Name +
                typeof(T11).Name +
                typeof(T12).Name
            ;
            if (Queries12.ContainsKey(queryName))
            {
                foreach (var obj in Queries12[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                        typeof(T7).Name,
                        typeof(T8).Name,
                        typeof(T9).Name,
                        typeof(T10).Name,
                        typeof(T11).Name,
                        typeof(T12).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            where T12 : Object
            where T13 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name +
                typeof(T7).Name +
                typeof(T8).Name +
                typeof(T9).Name +
                typeof(T10).Name +
                typeof(T11).Name +
                typeof(T12).Name +
                typeof(T13).Name
            ;
            if (Queries13.ContainsKey(queryName))
            {
                foreach (var obj in Queries13[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                        typeof(T7).Name,
                        typeof(T8).Name,
                        typeof(T9).Name,
                        typeof(T10).Name,
                        typeof(T11).Name,
                        typeof(T12).Name,
                        typeof(T13).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            where T12 : Object
            where T13 : Object
            where T14 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name +
                typeof(T7).Name +
                typeof(T8).Name +
                typeof(T9).Name +
                typeof(T10).Name +
                typeof(T11).Name +
                typeof(T12).Name +
                typeof(T13).Name +
                typeof(T14).Name
            ;
            if (Queries14.ContainsKey(queryName))
            {
                foreach (var obj in Queries14[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                        typeof(T7).Name,
                        typeof(T8).Name,
                        typeof(T9).Name,
                        typeof(T10).Name,
                        typeof(T11).Name,
                        typeof(T12).Name,
                        typeof(T13).Name,
                        typeof(T14).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            where T12 : Object
            where T13 : Object
            where T14 : Object
            where T15 : Object
        {
            var queryName = 
                typeof(T0).Name +
                typeof(T1).Name +
                typeof(T2).Name +
                typeof(T3).Name +
                typeof(T4).Name +
                typeof(T5).Name +
                typeof(T6).Name +
                typeof(T7).Name +
                typeof(T8).Name +
                typeof(T9).Name +
                typeof(T10).Name +
                typeof(T11).Name +
                typeof(T12).Name +
                typeof(T13).Name +
                typeof(T14).Name +
                typeof(T15).Name
            ;
            if (Queries15.ContainsKey(queryName))
            {
                foreach (var obj in Queries15[queryName])
                    yield return obj.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
            }
            else
            {
                BuildQuery(
                    queryName,
                    new List<string>
                    {
                        typeof(T0).Name,
                        typeof(T1).Name,
                        typeof(T2).Name,
                        typeof(T3).Name,
                        typeof(T4).Name,
                        typeof(T5).Name,
                        typeof(T6).Name,
                        typeof(T7).Name,
                        typeof(T8).Name,
                        typeof(T9).Name,
                        typeof(T10).Name,
                        typeof(T11).Name,
                        typeof(T12).Name,
                        typeof(T13).Name,
                        typeof(T14).Name,
                        typeof(T15).Name,
                    }
                );
                foreach (var obj in Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>())
                {
                    yield return obj;
                }
            }
            yield break;
        }

        #endregion

        public static async void ChangeScene(string path)
        {
            var currentScene = MainTree.CurrentScene;
            var inst = GD.Load<PackedScene>(path).Instance();
            currentScene.QueueFree();
            await Self.ToSignal(currentScene, "tree_exited");
            Root.SetMeta("current_scene", inst);
            Root.CallDeferred("add_child", inst);
            MainTree.SetDeferred("current_scene", inst);
            await Self.ToSignal(inst, "ready");
            PostChangeScene();
        }

        private static void PostChangeScene()
        {
            var registeredScenes = MainTree.GetNodesInGroup(_UnregisteredScene);
            if (registeredScenes.Count > 0)
            {
                foreach (Node scene in registeredScenes)
                {
                    scene.RemoveFromGroup(_UnregisteredScene);
                    RegisterAsScene(scene);
                }
            }
            else
            {
                RegisterAsScene(MainTree.CurrentScene);
            }
        }

        private static void RegisterAsScene(Node scene)
        {
            scene.AddToGroup(_RegisteredScene);
            scene.Connect("child_entered_tree", Self, nameof(_EntityEnteredScene));
            scene.Connect("child_exiting_tree", Self, nameof(_EntityExitingScene));
            foreach (Node child in scene.GetChildren())
            {
                RegisterEntity(child);
            }
        }

        private static void RegisterEntity(Node entity)
        {
            entity.Connect("child_entered_tree", Self, nameof(_EntityComponentAdded), new Godot.Collections.Array { entity });
            BindToQueries(entity);
        }

        private static void BuildQuery(string queryName, in List<string> componentNames)
        {
            var registeredScenes = Self.GetTree().GetNodesInGroup(_RegisteredScene);
            Templates[queryName] = componentNames;
            foreach (Node scene in registeredScenes)
            {
                foreach (Node entity in scene.GetChildren())
                {
                    if (entity.IsInGroup(_RegisteredScene)) continue;
                    BindToGroup(entity, queryName, componentNames);
                }
            }
        }

        private static void BindToQueries(Node entity)
        {
            foreach (var subTemplate in Templates)
            {
                BindToGroup(entity, subTemplate.Key, subTemplate.Value);
            }
        }

        private static void BindToGroup(Node entity, string queryName, List<string> componentNames)
        {
            if (entity.GetType().Name != componentNames[0]) return;
            var binds = entity.GetMeta(queryName + "#", new Godot.Collections.Array()) as Godot.Collections.Array;
            var queryNames = entity.GetMeta(_QueryNames, new Godot.Collections.Array()) as Godot.Collections.Array;
            var queryObjects = entity.GetMeta(queryName + "$", new Godot.Collections.Array()) as Godot.Collections.Array;
            var queryObject = new QueryObject();
            if (!queryNames.Contains(queryName))
            {
                componentNames = new List<string>(componentNames);
                componentNames.RemoveAt(0);
                foreach (var componentName in componentNames)
                {
                    if (entity.GetNodeOrNull(componentName) is not Node component) return;
                    binds.Add(component);
                    if (!entity.IsConnected("tree_exited", Self, nameof(_EntityComponentRemoved)))
                    {
                        component.Connect("tree_exited", Self, nameof(_EntityComponentRemoved), new Godot.Collections.Array { entity, componentName, queryNames }, (uint)ConnectFlags.Oneshot);
                    }
                }
                if (binds.Count == componentNames.Count)
                {
                    entity.AddToGroup(queryName);
                    entity.SetMeta(queryName + "#", binds);
                    entity.SetMeta(_QueryNames, queryNames);
                    entity.SetMeta(queryName + "$", queryObjects);
                    queryNames.Add(queryName);
                }
            }
            binds.Insert(0, entity);
            # region Save Query
            switch (binds.Count)
            {
                case 1:
                    {
                        var gObj = new QueryObject0();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        if (Queries0.ContainsKey(queryName)) Queries0[queryName].Add(gObj);
                        else Queries0.Add(queryName, new List<QueryObject0> { gObj });
                    }
                    break;

                case 2:
                    {
                        var gObj = new QueryObject1();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        if (Queries1.ContainsKey(queryName)) Queries1[queryName].Add(gObj);
                        else Queries1.Add(queryName, new List<QueryObject1> { gObj });
                    }
                    break;
                case 3:
                    {
                        var gObj = new QueryObject2();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        if (Queries2.ContainsKey(queryName)) Queries2[queryName].Add(gObj);
                        else Queries2.Add(queryName, new List<QueryObject2> { gObj });
                    }
                    break;
                case 4:
                    {
                        var gObj = new QueryObject3();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        if (Queries3.ContainsKey(queryName)) Queries3[queryName].Add(gObj);
                        else Queries3.Add(queryName, new List<QueryObject3> { gObj });
                    }
                    break;
                case 5:
                    {
                        var gObj = new QueryObject4();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        if (Queries4.ContainsKey(queryName)) Queries4[queryName].Add(gObj);
                        else Queries4.Add(queryName, new List<QueryObject4> { gObj });
                    }
                    break;
                case 6:
                    {
                        var gObj = new QueryObject5();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        if (Queries5.ContainsKey(queryName)) Queries5[queryName].Add(gObj);
                        else Queries5.Add(queryName, new List<QueryObject5> { gObj });
                    }
                    break;
                case 7:
                    {
                        var gObj = new QueryObject6();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        if (Queries6.ContainsKey(queryName)) Queries6[queryName].Add(gObj);
                        else Queries6.Add(queryName, new List<QueryObject6> { gObj });
                    }
                    break;
                case 8:
                    {
                        var gObj = new QueryObject7();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        if (Queries7.ContainsKey(queryName)) Queries7[queryName].Add(gObj);
                        else Queries7.Add(queryName, new List<QueryObject7> { gObj });
                    }
                    break;
                case 9:
                    {
                        var gObj = new QueryObject8();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        if (Queries8.ContainsKey(queryName)) Queries8[queryName].Add(gObj);
                        else Queries8.Add(queryName, new List<QueryObject8> { gObj });
                    }
                    break;
                case 10:
                    {
                        var gObj = new QueryObject9();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        gObj._obj9 = binds[9] as Node;
                        if (Queries9.ContainsKey(queryName)) Queries9[queryName].Add(gObj);
                        else Queries9.Add(queryName, new List<QueryObject9> { gObj });
                    }
                    break;
                case 11:
                    {
                        var gObj = new QueryObject10();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        gObj._obj9 = binds[9] as Node;
                        gObj._obj10 = binds[10] as Node;
                        if (Queries10.ContainsKey(queryName)) Queries10[queryName].Add(gObj);
                        else Queries10.Add(queryName, new List<QueryObject10> { gObj });
                    }
                    break;
                case 12:
                    {
                        var gObj = new QueryObject11();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        gObj._obj9 = binds[9] as Node;
                        gObj._obj10 = binds[10] as Node;
                        gObj._obj11 = binds[11] as Node;
                        if (Queries11.ContainsKey(queryName)) Queries11[queryName].Add(gObj);
                        else Queries11.Add(queryName, new List<QueryObject11> { gObj });
                    }
                    break;
                case 13:
                    {
                        var gObj = new QueryObject12();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        gObj._obj9 = binds[9] as Node;
                        gObj._obj10 = binds[10] as Node;
                        gObj._obj11 = binds[11] as Node;
                        gObj._obj12 = binds[12] as Node;
                        if (Queries12.ContainsKey(queryName)) Queries12[queryName].Add(gObj);
                        else Queries12.Add(queryName, new List<QueryObject12> { gObj });
                    }
                    break;
                case 14:
                    {
                        var gObj = new QueryObject13();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        gObj._obj9 = binds[9] as Node;
                        gObj._obj10 = binds[10] as Node;
                        gObj._obj11 = binds[11] as Node;
                        gObj._obj12 = binds[12] as Node;
                        gObj._obj13 = binds[13] as Node;
                        if (Queries13.ContainsKey(queryName)) Queries13[queryName].Add(gObj);
                        else Queries13.Add(queryName, new List<QueryObject13> { gObj });
                    }
                    break;
                case 15:
                    {
                        var gObj = new QueryObject14();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        gObj._obj9 = binds[9] as Node;
                        gObj._obj10 = binds[10] as Node;
                        gObj._obj11 = binds[11] as Node;
                        gObj._obj12 = binds[12] as Node;
                        gObj._obj13 = binds[13] as Node;
                        gObj._obj14 = binds[14] as Node;
                        if (Queries14.ContainsKey(queryName)) Queries14[queryName].Add(gObj);
                        else Queries14.Add(queryName, new List<QueryObject14> { gObj });
                    }
                    break;
                case 16:
                    {
                        var gObj = new QueryObject15();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        gObj._obj9 = binds[9] as Node;
                        gObj._obj10 = binds[10] as Node;
                        gObj._obj11 = binds[11] as Node;
                        gObj._obj12 = binds[12] as Node;
                        gObj._obj13 = binds[13] as Node;
                        gObj._obj14 = binds[14] as Node;
                        gObj._obj15 = binds[15] as Node;
                        if (Queries15.ContainsKey(queryName)) Queries15[queryName].Add(gObj);
                        else Queries15.Add(queryName, new List<QueryObject15> { gObj });
                    }
                    break;
                case 17:
                    {
                        var gObj = new QueryObject16();
                        queryObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        gObj._obj9 = binds[9] as Node;
                        gObj._obj10 = binds[10] as Node;
                        gObj._obj11 = binds[11] as Node;
                        gObj._obj12 = binds[12] as Node;
                        gObj._obj13 = binds[13] as Node;
                        gObj._obj14 = binds[14] as Node;
                        gObj._obj15 = binds[15] as Node;
                        gObj._obj16 = binds[16] as Node;
                        if (Queries16.ContainsKey(queryName)) Queries16[queryName].Add(gObj);
                        else Queries16.Add(queryName, new List<QueryObject16> { gObj });
                    }
                    break;
            }
            #endregion
            binds.RemoveAt(0);
        }

        public override void _EnterTree()
        {
            MainTree = GetTree();
            Root = MainTree.Root;
            Self = this;
        }

        private async void _EntityEnteredScene(Node entity)
        {
            await ToSignal(entity, "ready");
            RegisterEntity(entity);
        }

        private void _EntityExitingScene(Node entity)
        {
            foreach (Node component in entity.GetChildren())
            {
                component.EmitSignal("tree_exited");
            }
        }

        private void _EntityComponentAdded(Node newComponent, Node entity)
        {
            _EntityExitingScene(entity);
            BindToQueries(entity);
        }

        private void _EntityComponentRemoved(Node entity, string componentName, Godot.Collections.Array queryNames)
        {
            foreach (string queryName in queryNames)
            {
                if (!queryName.Contains(componentName))
                {
                    continue;
                }
                var queryObjects = entity.GetMeta(queryName + "$", new Godot.Collections.Array()) as Godot.Collections.Array;
                entity.RemoveMeta(queryName + "#");
                entity.RemoveMeta(queryName + "$");
                entity.RemoveFromGroup(queryName);
                foreach (QueryObject queryObject in queryObjects)
                {
                    switch (queryObject)
                    {
                        case QueryObject0 queryObject0: Queries0[queryName].Remove(queryObject0); break;
                        case QueryObject1 queryObject1: Queries1[queryName].Remove(queryObject1); break;
                        case QueryObject2 queryObject2: Queries2[queryName].Remove(queryObject2); break;
                        case QueryObject3 queryObject3: Queries3[queryName].Remove(queryObject3); break;
                        case QueryObject4 queryObject4: Queries4[queryName].Remove(queryObject4); break;
                        case QueryObject5 queryObject5: Queries5[queryName].Remove(queryObject5); break;
                        case QueryObject6 queryObject6: Queries6[queryName].Remove(queryObject6); break;
                        case QueryObject7 queryObject7: Queries7[queryName].Remove(queryObject7); break;
                        case QueryObject8 queryObject8: Queries8[queryName].Remove(queryObject8); break;
                        case QueryObject9 queryObject9: Queries9[queryName].Remove(queryObject9); break;
                        case QueryObject10 queryObject10: Queries10[queryName].Remove(queryObject10); break;
                        case QueryObject11 queryObject11: Queries11[queryName].Remove(queryObject11); break;
                        case QueryObject12 queryObject12: Queries12[queryName].Remove(queryObject12); break;
                        case QueryObject13 queryObject13: Queries13[queryName].Remove(queryObject13); break;
                        case QueryObject14 queryObject14: Queries14[queryName].Remove(queryObject14); break;
                        case QueryObject15 queryObject15: Queries15[queryName].Remove(queryObject15); break;
                        case QueryObject16 queryObject16: Queries16[queryName].Remove(queryObject16); break;
                    }
                    queryObject.Free();
                }
                queryObjects.Clear();
            }
        }

        public override void _Ready()
        {
            PostChangeScene();
        }
    }

    #region Query Class

    internal class QueryObject : Object
    {
    }

    internal class QueryObject0 : QueryObject
    {
        internal Object _obj0;
        public T Get<T>() where T : Object => _obj0 as T;
    }

    internal class QueryObject1 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        public (T0, T1) Get<T0, T1>()
            where T0 : Object
            where T1 : Object
            => (_obj0 as T0, _obj1 as T1);
    }

    internal class QueryObject2 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        public (T0, T1, T2) Get<T0, T1, T2>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            => (_obj0 as T0, _obj1 as T1, _obj2 as T2);
    }

    internal class QueryObject3 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        public (T0, T1, T2, T3) Get<T0, T1, T2, T3>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3
            );
    }

    internal class QueryObject4 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        public (T0, T1, T2, T3, T4) Get<T0, T1, T2, T3, T4>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4
            );
    }

    internal class QueryObject5 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        public (T0, T1, T2, T3, T4, T5) Get<T0, T1, T2, T3, T4, T5>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5
            );
    }

    internal class QueryObject6 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        public (T0, T1, T2, T3, T4, T5, T6) Get<T0, T1, T2, T3, T4, T5, T6>()
           where T0 : Object
           where T1 : Object
           where T2 : Object
           where T3 : Object
           where T4 : Object
           where T5 : Object
           where T6 : Object
           =>
           (
               _obj0 as T0,
               _obj1 as T1,
               _obj2 as T2,
               _obj3 as T3,
               _obj4 as T4,
               _obj5 as T5,
               _obj6 as T6
           );
    }

    internal class QueryObject7 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        public (T0, T1, T2, T3, T4, T5, T6, T7) Get<T0, T1, T2, T3, T4, T5, T6, T7>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5,
                _obj6 as T6,
                _obj7 as T7
            );
    }

    internal class QueryObject8 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        internal Object _obj8;
        public (T0, T1, T2, T3, T4, T5, T6, T7, T8) Get<T0, T1, T2, T3, T4, T5, T6, T7, T8>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5,
                _obj6 as T6,
                _obj7 as T7,
                _obj8 as T8
            );
    }

    internal class QueryObject9 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        internal Object _obj8;
        internal Object _obj9;
        public (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9) Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>()
        where T0 : Object
        where T1 : Object
        where T2 : Object
        where T3 : Object
        where T4 : Object
        where T5 : Object
        where T6 : Object
        where T7 : Object
        where T8 : Object
        where T9 : Object
        =>
        (
            _obj0 as T0,
            _obj1 as T1,
            _obj2 as T2,
            _obj3 as T3,
            _obj4 as T4,
            _obj5 as T5,
            _obj6 as T6,
            _obj7 as T7,
            _obj8 as T8,
            _obj9 as T9
        );
    }

    internal class QueryObject10 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        internal Object _obj8;
        internal Object _obj9;
        internal Object _obj10;
        public (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5,
                _obj6 as T6,
                _obj7 as T7,
                _obj8 as T8,
                _obj9 as T9,
                _obj10 as T10
            );
    }

    internal class QueryObject11 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        internal Object _obj8;
        internal Object _obj9;
        internal Object _obj10;
        internal Object _obj11;
        public (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11) Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5,
                _obj6 as T6,
                _obj7 as T7,
                _obj8 as T8,
                _obj9 as T9,
                _obj10 as T10,
                _obj11 as T11
            );
    }

    internal class QueryObject12 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        internal Object _obj8;
        internal Object _obj9;
        internal Object _obj10;
        internal Object _obj11;
        internal Object _obj12;
        public (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12) Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            where T12 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5,
                _obj6 as T6,
                _obj7 as T7,
                _obj8 as T8,
                _obj9 as T9,
                _obj10 as T10,
                _obj11 as T11,
                _obj12 as T12
            );
    }

    internal class QueryObject13 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        internal Object _obj8;
        internal Object _obj9;
        internal Object _obj10;
        internal Object _obj11;
        internal Object _obj12;
        internal Object _obj13;
        public (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13) Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            where T12 : Object
            where T13 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5,
                _obj6 as T6,
                _obj7 as T7,
                _obj8 as T8,
                _obj9 as T9,
                _obj10 as T10,
                _obj11 as T11,
                _obj12 as T12,
                _obj13 as T13
            );
    }

    internal class QueryObject14 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        internal Object _obj8;
        internal Object _obj9;
        internal Object _obj10;
        internal Object _obj11;
        internal Object _obj12;
        internal Object _obj13;
        internal Object _obj14;
        public (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14) Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            where T12 : Object
            where T13 : Object
            where T14 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5,
                _obj6 as T6,
                _obj7 as T7,
                _obj8 as T8,
                _obj9 as T9,
                _obj10 as T10,
                _obj11 as T11,
                _obj12 as T12,
                _obj13 as T13,
                _obj14 as T14
            );
    }

    internal class QueryObject15 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        internal Object _obj8;
        internal Object _obj9;
        internal Object _obj10;
        internal Object _obj11;
        internal Object _obj12;
        internal Object _obj13;
        internal Object _obj14;
        internal Object _obj15;
        public (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15) Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            where T12 : Object
            where T13 : Object
            where T14 : Object
            where T15 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5,
                _obj6 as T6,
                _obj7 as T7,
                _obj8 as T8,
                _obj9 as T9,
                _obj10 as T10,
                _obj11 as T11,
                _obj12 as T12,
                _obj13 as T13,
                _obj14 as T14,
                _obj15 as T15
            );
    }

    internal class QueryObject16 : QueryObject
    {
        internal Object _obj0;
        internal Object _obj1;
        internal Object _obj2;
        internal Object _obj3;
        internal Object _obj4;
        internal Object _obj5;
        internal Object _obj6;
        internal Object _obj7;
        internal Object _obj8;
        internal Object _obj9;
        internal Object _obj10;
        internal Object _obj11;
        internal Object _obj12;
        internal Object _obj13;
        internal Object _obj14;
        internal Object _obj15;
        internal Object _obj16;
        public (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16) Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
            where T8 : Object
            where T9 : Object
            where T10 : Object
            where T11 : Object
            where T12 : Object
            where T13 : Object
            where T14 : Object
            where T15 : Object
            where T16 : Object
            =>
            (
                _obj0 as T0,
                _obj1 as T1,
                _obj2 as T2,
                _obj3 as T3,
                _obj4 as T4,
                _obj5 as T5,
                _obj6 as T6,
                _obj7 as T7,
                _obj8 as T8,
                _obj9 as T9,
                _obj10 as T10,
                _obj11 as T11,
                _obj12 as T12,
                _obj13 as T13,
                _obj14 as T14,
                _obj15 as T15,
                _obj16 as T16
            );
    }

    #endregion
}
