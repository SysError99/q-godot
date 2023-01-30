using Godot;
using System.Linq;
using System.Collections.Generic;
using Array = Godot.Collections.Array;
using String = System.String;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;
using NullReferenceException = System.NullReferenceException;
using RankException = System.RankException;

namespace SysError99
{
    public class QGodotSharp : Node
    {
        private const string QGodotNotReadyExceptionMessage = "QGodot core isn't ready yet, consider await next frame before challing this funciton.";

        private static Object QGodot;
        private static Viewport Root;
        private static SceneTree MainTree;
        private static QGodotSharp Self;
        private static Dictionary<string, Dictionary<ulong, QueryObject0>> Queries0 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject1>> Queries1 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject2>> Queries2 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject3>> Queries3 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject4>> Queries4 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject5>> Queries5 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject6>> Queries6 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject7>> Queries7 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject8>> Queries8 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject9>> Queries9 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject10>> Queries10 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject11>> Queries11 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject12>> Queries12 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject13>> Queries13 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject14>> Queries14 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject15>> Queries15 = new();
        private static Dictionary<string, Dictionary<ulong, QueryObject16>> Queries16 = new();
        private static Dictionary<string, List<SystemOneshotBinder>> SubscribedSystems = new();
        private static Dictionary<string, List<SystemOneshotBinder>> CurrentSceneSubscribedSystems = new();

        private static List<Array> PreQueryList = new();

        # region Query Bind
        public static void BindQuery<T>(Object system, string functionName, bool toCurrentScene = false)
            where T : Object
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
                {
                    typeof(T).Name,
                }
            );
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T>();
        }

        public static void BindQuery<T0, T1>(Object system, string functionName, bool toCurrentScene = false)
            where T0 : Object
            where T1 : Object
        {
            var (queryName, componentNames) = PrepareQuery(new Array
            {
                typeof(T0).Name,
                typeof(T1).Name,
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1>();
        }

        public static void BindQuery<T0, T1, T2>(Object system, string functionName, bool toCurrentScene = false)
            where T0 : Object
            where T1 : Object
            where T2 : Object
        {
            var (queryName, componentNames) = PrepareQuery(new Array
            {
                typeof(T0).Name,
                typeof(T1).Name,
                typeof(T2).Name,
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2>();
        }

        public static void BindQuery<T0, T1, T2, T3>(Object system, string functionName, bool toCurrentScene = false)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
        {
            var (queryName, componentNames) = PrepareQuery(new Array
            {
                typeof(T0).Name,
                typeof(T1).Name,
                typeof(T2).Name,
                typeof(T3).Name,
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4>(Object system, string functionName, bool toCurrentScene = false)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
        {
            var (queryName, componentNames) = PrepareQuery(new Array
            {
                typeof(T0).Name,
                typeof(T1).Name,
                typeof(T2).Name,
                typeof(T3).Name,
                typeof(T4).Name,
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5>(Object system, string functionName, bool toCurrentScene = false)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
        {
            var (queryName, componentNames) = PrepareQuery(new Array
            {
                typeof(T0).Name,
                typeof(T1).Name,
                typeof(T2).Name,
                typeof(T3).Name,
                typeof(T4).Name,
                typeof(T5).Name,
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6>(Object system, string functionName, bool toCurrentScene = false)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
        {
            var (queryName, componentNames) = PrepareQuery(new Array
            {
                typeof(T0).Name,
                typeof(T1).Name,
                typeof(T2).Name,
                typeof(T3).Name,
                typeof(T4).Name,
                typeof(T5).Name,
                typeof(T6).Name,
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7>(Object system, string functionName, bool toCurrentScene = false)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
        {
            var (queryName, componentNames) = PrepareQuery(new Array
            {
                typeof(T0).Name,
                typeof(T1).Name,
                typeof(T2).Name,
                typeof(T3).Name,
                typeof(T4).Name,
                typeof(T5).Name,
                typeof(T6).Name,
                typeof(T7).Name,
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8>(Object system, string functionName, bool toCurrentScene = false)
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
            var (queryName, componentNames) = PrepareQuery(new Array
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
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Object system, string functionName, bool toCurrentScene = false)
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
            var (queryName, componentNames) = PrepareQuery(new Array
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
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Object system, string functionName, bool toCurrentScene = false)
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
            var (queryName, componentNames) = PrepareQuery(new Array
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
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Object system, string functionName, bool toCurrentScene = false)
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
            var (queryName, componentNames) = PrepareQuery(new Array
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
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Object system, string functionName, bool toCurrentScene = false)
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
            var (queryName, componentNames) = PrepareQuery(new Array
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
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Object system, string functionName, bool toCurrentScene = false)
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
            var (queryName, componentNames) = PrepareQuery(new Array
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
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Object system, string functionName, bool toCurrentScene = false)
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
            var (queryName, componentNames) = PrepareQuery(new Array
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
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Object system, string functionName, bool toCurrentScene = false)
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
            var (queryName, componentNames) = PrepareQuery(new Array
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
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Object system, string functionName, bool toCurrentScene = false)
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
        {
            var (queryName, componentNames) = PrepareQuery(new Array
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
                typeof(T16).Name,
            });
            BindQuery(queryName, componentNames, system, functionName, toCurrentScene);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();
        }

        private static void BindQuery(string queryName, Array componentNames, Object system, string functionName, bool toCurrentScene)
        {
            var systemBinder = new SystemOneshotBinder(system, functionName);
            if (!SubscribedSystems.ContainsKey(queryName))
            {
                SubscribedSystems.Add(queryName, new List<SystemOneshotBinder>() { systemBinder });
            }
            else
            {
                SubscribedSystems[queryName].Add(systemBinder);
            }
            if (toCurrentScene)
            {
                if (!CurrentSceneSubscribedSystems.ContainsKey(queryName))
                {
                    CurrentSceneSubscribedSystems.Add(queryName, new List<SystemOneshotBinder>() { systemBinder });
                }
                else
                {
                    CurrentSceneSubscribedSystems[queryName].Add(systemBinder);
                }
            }
            if (!IsInstanceValid(QGodot))
            {
                throw new NullReferenceException(QGodotNotReadyExceptionMessage);
            }
            else
            {
                QGodot.Call("bind_query", componentNames, system, functionName, toCurrentScene);
            }
        }
        # endregion

        #region Query
        public static IEnumerable<T0> Query<T0>()
            where T0 : Object
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
                {
                    typeof(T0).Name,
                }  
            );
            if (!Queries0.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries0[queryName].Values)
            {
                yield return q.Get<T0>();
            }
        }

        public static IEnumerable<(T0, T1)> Query<T0, T1>()
            where T0 : Object
            where T1 : Object
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
                {
                    typeof(T0).Name,
                    typeof(T1).Name,
                }  
            );
            if (!Queries1.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries1[queryName].Values)
            {
                yield return q.Get<T0, T1>();
            }
        }

        public static IEnumerable<(T0, T1, T2)> Query<T0, T1, T2>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
                {
                    typeof(T0).Name,
                    typeof(T1).Name,
                    typeof(T2).Name,
                }  
            );
            if (!Queries2.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries2[queryName].Values)
            {
                yield return q.Get<T0, T1, T2>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3)> Query<T0, T1, T2, T3>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
                {
                    typeof(T0).Name,
                    typeof(T1).Name,
                    typeof(T2).Name,
                    typeof(T3).Name,
                }  
            );
            if (!Queries3.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries3[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4)> Query<T0, T1, T2, T3, T4>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
                {
                    typeof(T0).Name,
                    typeof(T1).Name,
                    typeof(T2).Name,
                    typeof(T3).Name,
                    typeof(T4).Name,
                }  
            );
            if (!Queries4.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries4[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5)> Query<T0, T1, T2, T3, T4, T5>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
                {
                    typeof(T0).Name,
                    typeof(T1).Name,
                    typeof(T2).Name,
                    typeof(T3).Name,
                    typeof(T4).Name,
                    typeof(T5).Name,
                }  
            );
            if (!Queries5.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries5[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries6.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries6[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries7.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries7[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries8.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries8[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries9.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries9[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries10.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries10[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries11.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries11[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries12.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries12[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries13.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries13[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries14.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries14[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
            }
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
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
            if (!Queries15.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries15[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
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
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
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
                    typeof(T16).Name,
                }  
            );
            if (!Queries16.ContainsKey(queryName))
            {
                Query(queryName, componentNames);
            }
            foreach (var q in Queries16[queryName].Values)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();
            }
        }

        private static void Query(string queryName, Array componentNames)
        {
            if (IsInstanceValid(QGodot))
            {
                QGodot.Call("query", componentNames);
                return;
            }
            QueryAdd(queryName, componentNames.Count);
            PreQueryList.Add(componentNames);
            return;
        }
        #endregion
        
        public static void ChangeScene(string path)
        {
            foreach (var queryName in CurrentSceneSubscribedSystems.Keys)
            {
                var systems = SubscribedSystems[queryName];
                foreach (var system in CurrentSceneSubscribedSystems[queryName])
                {
                    systems.Remove(system);
                }
            }
            CurrentSceneSubscribedSystems.Clear();
            if (!IsInstanceValid(QGodot))
            {
                throw new NullReferenceException(QGodotNotReadyExceptionMessage);
            }
            else
            {
                QGodot.Call("change_scene", path);
            }
        }

        public static void RegisterAsScene(Node node)
        {
            if (!IsInstanceValid(QGodot))
            {
                throw new NullReferenceException(QGodotNotReadyExceptionMessage);
            }
            else
            {
                QGodot.Call("register_as_scene", node);
            }
        }
        
        private static (string, Array) PrepareQuery(Array componentNames)
        {
            return (String.Join("_", Enumerable.Cast<string>(componentNames)), componentNames);
        }

        private static void QueryAdd(string queryName, int bindsSize)
        {
            switch (bindsSize)
            {
                case 0:
                    throw new RankException("Bind size cannot be zero");
                case 1:
                    if (Queries0.ContainsKey(queryName)) return;
                    Queries0.Add(queryName, new Dictionary<ulong, QueryObject0>());
                    break;
                case 2:
                    if (Queries1.ContainsKey(queryName)) return;
                    Queries1.Add(queryName, new Dictionary<ulong, QueryObject1>());
                    break;
                case 3:
                    if (Queries2.ContainsKey(queryName)) return;
                    Queries2.Add(queryName, new Dictionary<ulong, QueryObject2>());
                    break;
                case 4:
                    if (Queries3.ContainsKey(queryName)) return;
                    Queries3.Add(queryName, new Dictionary<ulong, QueryObject3>());
                    break;
                case 5:
                    if (Queries4.ContainsKey(queryName)) return;
                    Queries4.Add(queryName, new Dictionary<ulong, QueryObject4>());
                    break;
                case 6:
                    if (Queries5.ContainsKey(queryName)) return;
                    Queries5.Add(queryName, new Dictionary<ulong, QueryObject5>());
                    break;
                case 7:
                    if (Queries6.ContainsKey(queryName)) return;
                    Queries6.Add(queryName, new Dictionary<ulong, QueryObject6>());
                    break;
                case 8:
                    if (Queries7.ContainsKey(queryName)) return;
                    Queries7.Add(queryName, new Dictionary<ulong, QueryObject7>());
                    break;
                case 9:
                    if (Queries8.ContainsKey(queryName)) return;
                    Queries8.Add(queryName, new Dictionary<ulong, QueryObject8>());
                    break;
                case 10:
                    if (Queries9.ContainsKey(queryName)) return;
                    Queries9.Add(queryName, new Dictionary<ulong, QueryObject9>());
                    break;
                case 11:
                    if (Queries10.ContainsKey(queryName)) return;
                    Queries10.Add(queryName, new Dictionary<ulong, QueryObject10>());
                    break;
                case 12:
                    if (Queries11.ContainsKey(queryName)) return;
                    Queries11.Add(queryName, new Dictionary<ulong, QueryObject11>());
                    break;
                case 13:
                    if (Queries12.ContainsKey(queryName)) return;
                    Queries12.Add(queryName, new Dictionary<ulong, QueryObject12>());
                    break;
                case 14:
                    if (Queries13.ContainsKey(queryName)) return;
                    Queries13.Add(queryName, new Dictionary<ulong, QueryObject13>());
                    break;
                case 15:
                    if (Queries14.ContainsKey(queryName)) return;
                    Queries14.Add(queryName, new Dictionary<ulong, QueryObject14>());
                    break;
                case 16:
                    if (Queries15.ContainsKey(queryName)) return;
                    Queries15.Add(queryName, new Dictionary<ulong, QueryObject15>());
                    break;
                case 17:
                    if (Queries16.ContainsKey(queryName)) return;
                    Queries16.Add(queryName, new Dictionary<ulong, QueryObject16>());
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Tuple count can be maximum at 17!");
            }
        }

        private static void AddToQuery(string queryName, Array binds)
        {
            var entityId = (binds[0] as Object).GetInstanceId();
            switch (binds.Count)
            {
                case 0:
                    throw new RankException("Bind size cannot be zero.");
                case 1:
                    {
                        var queries = Queries0[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject0();
                        query.Object0 = binds[0] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 2:
                    {
                        var queries = Queries1[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject1();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 3:
                    {
                        var queries = Queries2[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject2();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 4:
                    {
                        var queries = Queries3[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject3();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 5:
                    {
                        var queries = Queries4[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject4();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 6:
                    {
                        var queries = Queries5[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject5();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 7:
                    {
                        var queries = Queries6[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject6();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 8:
                    {
                        var queries = Queries7[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject7();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 9:
                    {
                        var queries = Queries8[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject8();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        query.Object8 = binds[8] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 10:
                    {
                        var queries = Queries9[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject9();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        query.Object8 = binds[8] as Object;
                        query.Object9 = binds[9] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 11:
                    {
                        var queries = Queries10[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject10();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        query.Object8 = binds[8] as Object;
                        query.Object9 = binds[9] as Object;
                        query.Object10 = binds[10] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 12:
                    {
                        var queries = Queries11[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject11();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        query.Object8 = binds[8] as Object;
                        query.Object9 = binds[9] as Object;
                        query.Object10 = binds[10] as Object;
                        query.Object11 = binds[11] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 13:
                    {
                        var queries = Queries12[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject12();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        query.Object8 = binds[8] as Object;
                        query.Object9 = binds[9] as Object;
                        query.Object10 = binds[10] as Object;
                        query.Object11 = binds[11] as Object;
                        query.Object12 = binds[12] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 14:
                    {
                        var queries = Queries13[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject13();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        query.Object8 = binds[8] as Object;
                        query.Object9 = binds[9] as Object;
                        query.Object10 = binds[10] as Object;
                        query.Object11 = binds[11] as Object;
                        query.Object12 = binds[12] as Object;
                        query.Object13 = binds[13] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 15:
                    {
                        var queries = Queries14[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject14();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        query.Object8 = binds[8] as Object;
                        query.Object9 = binds[9] as Object;
                        query.Object10 = binds[10] as Object;
                        query.Object11 = binds[11] as Object;
                        query.Object12 = binds[12] as Object;
                        query.Object13 = binds[13] as Object;
                        query.Object14 = binds[14] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 16:
                    {
                        var queries = Queries15[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject15();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        query.Object8 = binds[8] as Object;
                        query.Object9 = binds[9] as Object;
                        query.Object10 = binds[10] as Object;
                        query.Object11 = binds[11] as Object;
                        query.Object12 = binds[12] as Object;
                        query.Object13 = binds[13] as Object;
                        query.Object14 = binds[14] as Object;
                        query.Object15 = binds[15] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
                case 17:
                    {
                        var queries = Queries16[queryName];
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject16();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        query.Object6 = binds[6] as Object;
                        query.Object7 = binds[7] as Object;
                        query.Object8 = binds[8] as Object;
                        query.Object9 = binds[9] as Object;
                        query.Object10 = binds[10] as Object;
                        query.Object11 = binds[11] as Object;
                        query.Object12 = binds[12] as Object;
                        query.Object13 = binds[13] as Object;
                        query.Object14 = binds[14] as Object;
                        query.Object15 = binds[15] as Object;
                        query.Object16 = binds[16] as Object;
                        queries.Add(entityId, query);
                    }
                    break;
            }
        }

        public override void _EnterTree()
        {
            MainTree = GetTree();
            Root = MainTree.Root;
            Self = this;
            foreach (Object core in MainTree.GetNodesInGroup("#q-godot"))
            {
                QGodot = core;
                core.Connect("added_to_query", this, nameof(_AddToQuery));
                core.Connect("query_added", this, nameof(_QueryAdd));
                core.Connect("removed_from_query", this, nameof(_RemoveFromQuery));
                core.Disconnect("added_to_query", core, "_added_to_query");
                core.Disconnect("removed_from_query", core, "_removed_from_query");
                core.Set("_cache_enabled", false);
                foreach (var componentNames in PreQueryList)
                {
                    QGodot.Call("query", componentNames);
                }
                PreQueryList.Clear();
            }
        }

        private void _QueryAdd(string queryName, int bindsSize)
        {
            QueryAdd(queryName, bindsSize);
        }

        private void _AddToQuery(string queryName, Array binds)
        {
            AddToQuery(queryName, binds);
        }

        private void _RemoveFromQuery(string queryName, Array binds)
        {
            var entityId = (binds[0] as Object).GetInstanceId();
            switch (queryName.Split('_').Length)
            {
                case 1: Queries0[queryName].Remove(entityId); break;
                case 2: Queries1[queryName].Remove(entityId); break;
                case 3: Queries2[queryName].Remove(entityId); break;
                case 4: Queries3[queryName].Remove(entityId); break;
                case 5: Queries4[queryName].Remove(entityId); break;
                case 6: Queries5[queryName].Remove(entityId); break;
                case 7: Queries6[queryName].Remove(entityId); break;
                case 8: Queries7[queryName].Remove(entityId); break;
                case 9: Queries8[queryName].Remove(entityId); break;
                case 10: Queries9[queryName].Remove(entityId); break;
                case 11: Queries10[queryName].Remove(entityId); break;
                case 12: Queries11[queryName].Remove(entityId); break;
                case 13: Queries12[queryName].Remove(entityId); break;
                case 14: Queries13[queryName].Remove(entityId); break;
                case 15: Queries14[queryName].Remove(entityId); break;
                case 16: Queries15[queryName].Remove(entityId); break;
            }
        }
    }

    public class SystemOneshotBinder
    {
        public Object _system;
        internal string _functionName;
        internal List<string> _entitityNames = new();

        public SystemOneshotBinder(Object system, string functionName)
        {
            _functionName = functionName;
            _system = system;
        }
    }

    #region Query Class
    public class QueryObject : Object
    {
    }

    public class QueryObject0 : QueryObject
    {
        public Object Object0;
        public T Get<T>() where T : Object => Object0 as T;
    }

    public class QueryObject1 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public (T0, T1) Get<T0, T1>()
            where T0 : Object
            where T1 : Object
            => (Object0 as T0, Object1 as T1);
    }

    public class QueryObject2 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public (T0, T1, T2) Get<T0, T1, T2>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            => (Object0 as T0, Object1 as T1, Object2 as T2);
    }

    public class QueryObject3 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public (T0, T1, T2, T3) Get<T0, T1, T2, T3>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            =>
            (
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3
            );
    }

    public class QueryObject4 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public (T0, T1, T2, T3, T4) Get<T0, T1, T2, T3, T4>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            =>
            (
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4
            );
    }

    public class QueryObject5 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public (T0, T1, T2, T3, T4, T5) Get<T0, T1, T2, T3, T4, T5>()
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            =>
            (
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5
            );
    }

    public class QueryObject6 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
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
               Object0 as T0,
               Object1 as T1,
               Object2 as T2,
               Object3 as T3,
               Object4 as T4,
               Object5 as T5,
               Object6 as T6
           );
    }

    public class QueryObject7 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
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
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5,
                Object6 as T6,
                Object7 as T7
            );
    }

    public class QueryObject8 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
        public Object Object8;
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
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5,
                Object6 as T6,
                Object7 as T7,
                Object8 as T8
            );
    }

    public class QueryObject9 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
        public Object Object8;
        public Object Object9;
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
            Object0 as T0,
            Object1 as T1,
            Object2 as T2,
            Object3 as T3,
            Object4 as T4,
            Object5 as T5,
            Object6 as T6,
            Object7 as T7,
            Object8 as T8,
            Object9 as T9
        );
    }

    public class QueryObject10 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
        public Object Object8;
        public Object Object9;
        public Object Object10;
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
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5,
                Object6 as T6,
                Object7 as T7,
                Object8 as T8,
                Object9 as T9,
                Object10 as T10
            );
    }

    public class QueryObject11 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
        public Object Object8;
        public Object Object9;
        public Object Object10;
        public Object Object11;
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
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5,
                Object6 as T6,
                Object7 as T7,
                Object8 as T8,
                Object9 as T9,
                Object10 as T10,
                Object11 as T11
            );
    }

    public class QueryObject12 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
        public Object Object8;
        public Object Object9;
        public Object Object10;
        public Object Object11;
        public Object Object12;
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
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5,
                Object6 as T6,
                Object7 as T7,
                Object8 as T8,
                Object9 as T9,
                Object10 as T10,
                Object11 as T11,
                Object12 as T12
            );
    }

    public class QueryObject13 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
        public Object Object8;
        public Object Object9;
        public Object Object10;
        public Object Object11;
        public Object Object12;
        public Object Object13;
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
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5,
                Object6 as T6,
                Object7 as T7,
                Object8 as T8,
                Object9 as T9,
                Object10 as T10,
                Object11 as T11,
                Object12 as T12,
                Object13 as T13
            );
    }

    public class QueryObject14 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
        public Object Object8;
        public Object Object9;
        public Object Object10;
        public Object Object11;
        public Object Object12;
        public Object Object13;
        public Object Object14;
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
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5,
                Object6 as T6,
                Object7 as T7,
                Object8 as T8,
                Object9 as T9,
                Object10 as T10,
                Object11 as T11,
                Object12 as T12,
                Object13 as T13,
                Object14 as T14
            );
    }

    public class QueryObject15 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
        public Object Object8;
        public Object Object9;
        public Object Object10;
        public Object Object11;
        public Object Object12;
        public Object Object13;
        public Object Object14;
        public Object Object15;
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
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5,
                Object6 as T6,
                Object7 as T7,
                Object8 as T8,
                Object9 as T9,
                Object10 as T10,
                Object11 as T11,
                Object12 as T12,
                Object13 as T13,
                Object14 as T14,
                Object15 as T15
            );
    }

    public class QueryObject16 : QueryObject
    {
        public Object Object0;
        public Object Object1;
        public Object Object2;
        public Object Object3;
        public Object Object4;
        public Object Object5;
        public Object Object6;
        public Object Object7;
        public Object Object8;
        public Object Object9;
        public Object Object10;
        public Object Object11;
        public Object Object12;
        public Object Object13;
        public Object Object14;
        public Object Object15;
        public Object Object16;
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
                Object0 as T0,
                Object1 as T1,
                Object2 as T2,
                Object3 as T3,
                Object4 as T4,
                Object5 as T5,
                Object6 as T6,
                Object7 as T7,
                Object8 as T8,
                Object9 as T9,
                Object10 as T10,
                Object11 as T11,
                Object12 as T12,
                Object13 as T13,
                Object14 as T14,
                Object15 as T15,
                Object16 as T16
            );
    }

    #endregion
}
