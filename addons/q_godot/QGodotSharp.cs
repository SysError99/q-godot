using Godot;
using System.Linq;
using System.Collections.Generic;
using Array = Godot.Collections.Array;
using String = System.String;
using NullReferenceException = System.NullReferenceException;
using RankException = System.RankException;

namespace SysError99
{
    public class QGodotSharp : Node
    {
        private const string QGodotNotReadyExceptionMessage = "QGodot core isn't ready yet, consider await next frame before challing this funciton.";

        public static bool QGodotReady = false;

        public static Object QGodot;
        private static Viewport Root;
        private static SceneTree MainTree;
        private static QGodotSharp Self;
        private static Dictionary<string, HalfQuery> HalfQueries = new();
        private static Dictionary<string, Dictionary<ulong, object>> Queries = new();
        private static Dictionary<string, List<SystemOneshotBinder>> SubscribedSystems = new();

        private static List<Array> PreQueryList = new();

        public static SignalAwaiter Ready()
        {
            if (IsInstanceValid(QGodot))
            {
                return QGodot.ToSignal(QGodot, "query_ready");
            }
            throw new NullReferenceException("Core isn't ready yet!");
        }

        # region Query Bind
        public static void BindQuery<T>(Object system, string functionName)
            where T : Object
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
                {
                    typeof(T).Name,
                }
            );
            BindQuery(queryName, componentNames, system, functionName);
            Query<T>();
        }

        public static void BindQuery<T0, T1>(Object system, string functionName)
            where T0 : Object
            where T1 : Object
        {
            var (queryName, componentNames) = PrepareQuery(new Array
            {
                typeof(T0).Name,
                typeof(T1).Name,
            });
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1>();
        }

        public static void BindQuery<T0, T1, T2>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2>();
        }

        public static void BindQuery<T0, T1, T2, T3>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
        }

        public static void BindQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Object system, string functionName)
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
            BindQuery(queryName, componentNames, system, functionName);
            Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();
        }

        private static void BindQuery(string queryName, Array componentNames, Object system, string functionName)
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
            if (!IsInstanceValid(QGodot))
            {
                throw new NullReferenceException(QGodotNotReadyExceptionMessage);
            }
            else
            {
                var (parentClassName, c) = GetGDScriptQueryParams(componentNames);
                QGodot.Call("bind_query", parentClassName, c, system, functionName);
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
            return Query<T0>(Queries[queryName].Values);
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
            return Query<T0, T1>(Queries[queryName].Values);
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
            return Query<T0, T1, T2>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7, T8>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Queries[queryName].Values);
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
            return Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Queries[queryName].Values);
        }

        public static IEnumerable<T0> Query<T0>(Dictionary<ulong, object>.ValueCollection queries)
            where T0 : Object
        {
            foreach (QueryObject0 q in queries)
            {
                yield return q.Get<T0>();
            }
        }

        public static IEnumerable<(T0, T1)> Query<T0, T1>(Dictionary<ulong, object>.ValueCollection queries)
            where T0 : Object
            where T1 : Object
        {
            foreach (QueryObject1 q in queries)
            {
                yield return q.Get<T0, T1>();
            }
        }

        public static IEnumerable<(T0, T1, T2)> Query<T0, T1, T2>(Dictionary<ulong, object>.ValueCollection queries)
            where T0 : Object
            where T1 : Object
            where T2 : Object
        {
            foreach (QueryObject2 q in queries)
            {
                yield return q.Get<T0, T1, T2>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3)> Query<T0, T1, T2, T3>(Dictionary<ulong, object>.ValueCollection queries)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
        {
            foreach (QueryObject3 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4)> Query<T0, T1, T2, T3, T4>(Dictionary<ulong, object>.ValueCollection queries)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
        {
            foreach (QueryObject4 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5)> Query<T0, T1, T2, T3, T4, T5>(Dictionary<ulong, object>.ValueCollection queries)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
        {
            foreach (QueryObject5 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6)> Query<T0, T1, T2, T3, T4, T5, T6>(Dictionary<ulong, object>.ValueCollection queries)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
        {
            foreach (QueryObject6 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7)> Query<T0, T1, T2, T3, T4, T5, T6, T7>(Dictionary<ulong, object>.ValueCollection queries)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
        {
            foreach (QueryObject7 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8>(Dictionary<ulong, object>.ValueCollection queries)
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
            foreach (QueryObject8 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Dictionary<ulong, object>.ValueCollection queries)
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
            foreach (QueryObject9 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Dictionary<ulong, object>.ValueCollection queries)
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
            foreach (QueryObject10 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Dictionary<ulong, object>.ValueCollection queries)
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
            foreach (QueryObject11 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Dictionary<ulong, object>.ValueCollection queries)
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
            foreach (QueryObject12 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Dictionary<ulong, object>.ValueCollection queries)
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
            foreach (QueryObject13 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Dictionary<ulong, object>.ValueCollection queries)
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
            foreach (QueryObject14 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Dictionary<ulong, object>.ValueCollection queries)
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
            foreach (QueryObject15 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)> Query<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Dictionary<ulong, object>.ValueCollection queries)
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
            foreach (QueryObject16 q in queries)
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();
            }
        }

        public static IEnumerable<T0> QueryHalf<T0>()
            where T0 : Object
        {
            var (queryName, componentNames) = PrepareQuery(
                new Array
                {
                    typeof(T0).Name,
                }  
            );
            return QueryHalf<T0>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1)> QueryHalf<T0, T1>()
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
            return QueryHalf<T0, T1>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2)> QueryHalf<T0, T1, T2>()
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
            return QueryHalf<T0, T1, T2>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3)> QueryHalf<T0, T1, T2, T3>()
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
            return QueryHalf<T0, T1, T2, T3>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4)> QueryHalf<T0, T1, T2, T3, T4>()
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
            return QueryHalf<T0, T1, T2, T3, T4>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5)> QueryHalf<T0, T1, T2, T3, T4, T5>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6)> QueryHalf<T0, T1, T2, T3, T4, T5, T6>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(HalfQueries[queryName]);
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
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
            return QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(HalfQueries[queryName]);
        }

        public static IEnumerable<T0> QueryHalf<T0>(HalfQuery halfQuery)
            where T0 : Object
        {
            foreach (QueryObject0 q in halfQuery.GetNext())
            {
                yield return q.Get<T0>();
            }
        }

        public static IEnumerable<(T0, T1)> QueryHalf<T0, T1>(HalfQuery halfQuery)
            where T0 : Object
            where T1 : Object
        {
            foreach (QueryObject1 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1>();
            }
        }

        public static IEnumerable<(T0, T1, T2)> QueryHalf<T0, T1, T2>(HalfQuery halfQuery)
            where T0 : Object
            where T1 : Object
            where T2 : Object
        {
            foreach (QueryObject2 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3)> QueryHalf<T0, T1, T2, T3>(HalfQuery halfQuery)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
        {
            foreach (QueryObject3 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4)> QueryHalf<T0, T1, T2, T3, T4>(HalfQuery halfQuery)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
        {
            foreach (QueryObject4 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5)> QueryHalf<T0, T1, T2, T3, T4, T5>(HalfQuery halfQuery)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
        {
            foreach (QueryObject5 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6)> QueryHalf<T0, T1, T2, T3, T4, T5, T6>(HalfQuery halfQuery)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
        {
            foreach (QueryObject6 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7>(HalfQuery halfQuery)
            where T0 : Object
            where T1 : Object
            where T2 : Object
            where T3 : Object
            where T4 : Object
            where T5 : Object
            where T6 : Object
            where T7 : Object
        {
            foreach (QueryObject7 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8>(HalfQuery halfQuery)
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
            foreach (QueryObject8 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(HalfQuery halfQuery)
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
            foreach (QueryObject9 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(HalfQuery halfQuery)
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
            foreach (QueryObject10 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(HalfQuery halfQuery)
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
            foreach (QueryObject11 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(HalfQuery halfQuery)
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
            foreach (QueryObject12 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(HalfQuery halfQuery)
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
            foreach (QueryObject13 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(HalfQuery halfQuery)
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
            foreach (QueryObject14 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(HalfQuery halfQuery)
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
            foreach (QueryObject15 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
            }
        }

        public static IEnumerable<(T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)> QueryHalf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(HalfQuery halfQuery)
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
            foreach (QueryObject16 q in halfQuery.GetNext())
            {
                yield return q.Get<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();
            }
        }

        #endregion

        public static void FlushAndChangeScene(string path)
        {
            if (!IsInstanceValid(QGodot))
            {
                throw new NullReferenceException(QGodotNotReadyExceptionMessage);
            }
            foreach (var query in Queries.Values)
            {
                foreach (Object queryObject in query.Values)
                {
                    queryObject.Free();
                }
            }
            foreach (var hq in HalfQueries.Values)
            {
                hq.Free();
            }
            Queries.Clear();
            HalfQueries.Clear();
            SubscribedSystems.Clear();
            QGodot.Call("flush_and_change_scene", path);
        }
        
        public static void ChangeScene(string path)
        {
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
            var queryName = String.Join(",", Enumerable.Cast<string>(componentNames));
            QueryAdd(queryName);
            if (IsInstanceValid(QGodot))
            {
                var (parentClassName, c) = GetGDScriptQueryParams(componentNames);
                QGodot.Call("query", parentClassName, c);
            }
            else
            {
                PreQueryList.Add(componentNames);
            }
            return (queryName, componentNames);
        }

        private static void QueryAdd(string queryName)
        {
            if (!Queries.ContainsKey(queryName))
            {
                Queries.Add(queryName, new Dictionary<ulong, dynamic>());
            }
            if (!HalfQueries.ContainsKey(queryName))
            {
                HalfQueries.Add(queryName, new HalfQuery());
            }
        }

        private static void AddToQuery(string queryName, Array binds)
        {
            var entityId = (binds[0] as Object).GetInstanceId();
            var queries = Queries[queryName];
            switch (binds.Count)
            {
                case 0:
                    throw new RankException("Bind size cannot be zero.");
                case 1:
                    {
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject0();
                        query.Object0 = binds[0] as Object;
                        queries.Add(entityId, query);
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 2:
                    {
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject1();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        queries.Add(entityId, query);
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 3:
                    {
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject2();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        queries.Add(entityId, query);
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 4:
                    {
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject3();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        queries.Add(entityId, query);
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 5:
                    {
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject4();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        queries.Add(entityId, query);
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 6:
                    {
                        if (queries.ContainsKey(entityId)) return;
                        var query = new QueryObject5();
                        query.Object0 = binds[0] as Object;
                        query.Object1 = binds[1] as Object;
                        query.Object2 = binds[2] as Object;
                        query.Object3 = binds[3] as Object;
                        query.Object4 = binds[4] as Object;
                        query.Object5 = binds[5] as Object;
                        queries.Add(entityId, query);
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 7:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 8:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 9:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 10:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 11:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 12:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 13:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 14:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 15:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 16:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
                case 17:
                    {
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
                        AddToHalfQuery(queryName, query);
                    }
                    break;
            }
        }

        public static void AddToHalfQuery(string queryName, Object obj)
        {
            if (!HalfQueries.ContainsKey(queryName)) return;
            var hq = HalfQueries[queryName];
            if (hq._firstHalf.Count > hq._secondHalf.Count)
            {
                hq._secondHalf.Add(obj);
            }
            else
            {
                hq._firstHalf.Add(obj);
            }
        }

        public static (string, Array) GetGDScriptQueryParams(Array componentNames)
        {
            componentNames = componentNames.Duplicate();
            var parentClassName = componentNames[0] as string;
            componentNames.RemoveAt(0);
            return (parentClassName, componentNames);
        }

        public override void _EnterTree()
        {
            MainTree = GetTree();
            Root = MainTree.Root;
            Self = this;
            foreach (Object core in MainTree.GetNodesInGroup("#q-godot"))
            {
                QGodot = core;
                QGodotReady = true;
                core.Connect("added_to_query", this, nameof(_AddToQuery));
                core.Connect("query_added", this, nameof(_QueryAdd));
                core.Connect("removed_from_query", this, nameof(_RemoveFromQuery));
                foreach (var componentNames in PreQueryList)
                {
                    var (parentClassName, c) = GetGDScriptQueryParams(componentNames);
                    QGodot.Call("query", parentClassName, c);
                }
                PreQueryList.Clear();
            }
        }

        private void _QueryAdd(string queryName)
        {
            QueryAdd(queryName);
        }

        private void _AddToQuery(string queryName, Array binds)
        {
            AddToQuery(queryName, binds);
        }

        private void _RemoveFromQuery(string queryName, Array binds)
        {
            var entity = binds[0] as Object;
            Queries[queryName].Remove(entity.GetInstanceId());
        }
    }

    public class SystemOneshotBinder
    {
        public Object _system;
        internal string _functionName;

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

    #region Half Query Class
    public class HalfQuery : Object
    {
        internal List<object> _firstHalf = new();
        internal List<object> _secondHalf = new();

        public List<object> GetNext()
        {
            return QGodotSharp.QGodotReady ? (bool) QGodotSharp.QGodot.Get("switch") ? _secondHalf : _firstHalf : _firstHalf;
        }
    }
    #endregion
}
