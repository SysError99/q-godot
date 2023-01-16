using Godot;
using System.Collections.Generic;

namespace SysError99
{
    public class QGodotSharp : Node
    {
        private const string _Component = "#C";
        private const string _RegisteredScene = "#RS";
        private const string _UnregisteredScene = "registered_scene";

        private static Viewport Root;
        private static SceneTree MainTree;
        private static QGodotSharp Self;
        private static Dictionary<string, List<GroupObject0>> Groups0 = new();
        private static Dictionary<string, List<GroupObject1>> Groups1 = new();
        private static Dictionary<string, List<GroupObject2>> Groups2 = new();
        private static Dictionary<string, List<GroupObject3>> Groups3 = new();
        private static Dictionary<string, List<GroupObject4>> Groups4 = new();
        private static Dictionary<string, List<GroupObject5>> Groups5 = new();
        private static Dictionary<string, List<GroupObject6>> Groups6 = new();
        private static Dictionary<string, List<GroupObject7>> Groups7 = new();
        private static Dictionary<string, List<GroupObject8>> Groups8 = new();
        private static Dictionary<string, List<GroupObject9>> Groups9 = new();
        private static Dictionary<string, List<GroupObject10>> Groups10 = new();
        private static Dictionary<string, List<GroupObject11>> Groups11 = new();
        private static Dictionary<string, List<GroupObject12>> Groups12 = new();
        private static Dictionary<string, List<GroupObject13>> Groups13 = new();
        private static Dictionary<string, List<GroupObject14>> Groups14 = new();
        private static Dictionary<string, List<GroupObject15>> Groups15 = new();
        private static Dictionary<string, List<GroupObject16>> Groups16 = new();
        private static Dictionary<string, List<string>> Templates = new();

        #region Query

        public static IEnumerable<T> Query<T>()
            where T : Object
        {
            var queryName =  typeof(T).Name;
            if (Groups0.ContainsKey(queryName))
            {
                foreach (var obj in Groups0[queryName])
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
            if (Groups1.ContainsKey(queryName))
            {
                foreach (var obj in Groups1[queryName])
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
            if (Groups2.ContainsKey(queryName))
            {
                foreach (var obj in Groups2[queryName])
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
            if (Groups3.ContainsKey(queryName))
            {
                foreach (var obj in Groups3[queryName])
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
            if (Groups4.ContainsKey(queryName))
            {
                foreach (var obj in Groups4[queryName])
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
            if (Groups5.ContainsKey(queryName))
            {
                foreach (var obj in Groups5[queryName])
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
            if (Groups6.ContainsKey(queryName))
            {
                foreach (var obj in Groups6[queryName])
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
            if (Groups7.ContainsKey(queryName))
            {
                foreach (var obj in Groups7[queryName])
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
            if (Groups8.ContainsKey(queryName))
            {
                foreach (var obj in Groups8[queryName])
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
            if (Groups9.ContainsKey(queryName))
            {
                foreach (var obj in Groups9[queryName])
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
            if (Groups10.ContainsKey(queryName))
            {
                foreach (var obj in Groups10[queryName])
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
            if (Groups11.ContainsKey(queryName))
            {
                foreach (var obj in Groups11[queryName])
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
            if (Groups12.ContainsKey(queryName))
            {
                foreach (var obj in Groups12[queryName])
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
            if (Groups13.ContainsKey(queryName))
            {
                foreach (var obj in Groups13[queryName])
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
            if (Groups14.ContainsKey(queryName))
            {
                foreach (var obj in Groups14[queryName])
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
            if (Groups15.ContainsKey(queryName))
            {
                foreach (var obj in Groups15[queryName])
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
            }
            yield break;
        }

        #endregion

        public static async void ChangeScene(string path)
        {
            var tree = Self.GetTree();
            var currentScene = tree.CurrentScene;
            var inst = GD.Load<PackedScene>(path).Instance();
            if (Object.IsInstanceValid(currentScene))
            {
                currentScene.QueueFree();
            }
            Root.AddChild(inst);
            MainTree.CurrentScene = inst;
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
            BindToGroups(entity);
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

        private static void BindToGroups(Node entity)
        {
            foreach (var subTemplate in Templates)
            {
                BindToGroup(entity, subTemplate.Key, subTemplate.Value);
            }
        }

        private static void BindToGroup(Node entity, string queryName, List<string> componentNames)
        {
            if (entity.GetType().Name != componentNames[0]) return;
            var binds = entity.GetMeta(queryName, new Godot.Collections.Array()) as Godot.Collections.Array;
            var groupObject = new GroupObject();
            if (binds.Count == 0)
            {
                componentNames = new List<string>(componentNames);
                componentNames.RemoveAt(0);
                foreach (var componentName in componentNames)
                {
                    if (entity.GetNodeOrNull(componentName) is not Node component) return;
                    component.AddToGroup(_Component);
                    binds.Add(component);
                }
                if (binds.Count == componentNames.Count)
                {
                    entity.SetMeta(queryName, binds);
                    foreach (Node component in binds)
                    {
                        component.Connect("tree_exited", Self, nameof(_EntityComponentRemoved), new Godot.Collections.Array { entity, component, groupObject, queryName }, (uint)ConnectFlags.Oneshot);
                    }
                }
            }
            binds.Insert(0, entity);
            # region Save Query
            switch (binds.Count)
            {
                case 1:
                    {
                        var gObj = new GroupObject0();
                        groupObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        if (Groups0.ContainsKey(queryName)) Groups0[queryName].Add(gObj);
                        else Groups0.Add(queryName, new List<GroupObject0> { gObj });
                    }
                    break;

                case 2:
                    {
                        var gObj = new GroupObject1();
                        groupObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        if (Groups1.ContainsKey(queryName)) Groups1[queryName].Add(gObj);
                        else Groups1.Add(queryName, new List<GroupObject1> { gObj });
                    }
                    break;
                case 3:
                    {
                        var gObj = new GroupObject2();
                        groupObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        if (Groups2.ContainsKey(queryName)) Groups2[queryName].Add(gObj);
                        else Groups2.Add(queryName, new List<GroupObject2> { gObj });
                    }
                    break;
                case 4:
                    {
                        var gObj = new GroupObject3();
                        groupObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        if (Groups3.ContainsKey(queryName)) Groups3[queryName].Add(gObj);
                        else Groups3.Add(queryName, new List<GroupObject3> { gObj });
                    }
                    break;
                case 5:
                    {
                        var gObj = new GroupObject4();
                        groupObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        if (Groups4.ContainsKey(queryName)) Groups4[queryName].Add(gObj);
                        else Groups4.Add(queryName, new List<GroupObject4> { gObj });
                    }
                    break;
                case 6:
                    {
                        var gObj = new GroupObject5();
                        groupObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        if (Groups5.ContainsKey(queryName)) Groups5[queryName].Add(gObj);
                        else Groups5.Add(queryName, new List<GroupObject5> { gObj });
                    }
                    break;
                case 7:
                    {
                        var gObj = new GroupObject6();
                        groupObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        if (Groups6.ContainsKey(queryName)) Groups6[queryName].Add(gObj);
                        else Groups6.Add(queryName, new List<GroupObject6> { gObj });
                    }
                    break;
                case 8:
                    {
                        var gObj = new GroupObject7();
                        groupObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        if (Groups7.ContainsKey(queryName)) Groups7[queryName].Add(gObj);
                        else Groups7.Add(queryName, new List<GroupObject7> { gObj });
                    }
                    break;
                case 9:
                    {
                        var gObj = new GroupObject8();
                        groupObject = gObj;
                        gObj._obj0 = binds[0] as Node;
                        gObj._obj1 = binds[1] as Node;
                        gObj._obj2 = binds[2] as Node;
                        gObj._obj3 = binds[3] as Node;
                        gObj._obj4 = binds[4] as Node;
                        gObj._obj5 = binds[5] as Node;
                        gObj._obj6 = binds[6] as Node;
                        gObj._obj7 = binds[7] as Node;
                        gObj._obj8 = binds[8] as Node;
                        if (Groups8.ContainsKey(queryName)) Groups8[queryName].Add(gObj);
                        else Groups8.Add(queryName, new List<GroupObject8> { gObj });
                    }
                    break;
                case 10:
                    {
                        var gObj = new GroupObject9();
                        groupObject = gObj;
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
                        if (Groups9.ContainsKey(queryName)) Groups9[queryName].Add(gObj);
                        else Groups9.Add(queryName, new List<GroupObject9> { gObj });
                    }
                    break;
                case 11:
                    {
                        var gObj = new GroupObject10();
                        groupObject = gObj;
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
                        if (Groups10.ContainsKey(queryName)) Groups10[queryName].Add(gObj);
                        else Groups10.Add(queryName, new List<GroupObject10> { gObj });
                    }
                    break;
                case 12:
                    {
                        var gObj = new GroupObject11();
                        groupObject = gObj;
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
                        if (Groups11.ContainsKey(queryName)) Groups11[queryName].Add(gObj);
                        else Groups11.Add(queryName, new List<GroupObject11> { gObj });
                    }
                    break;
                case 13:
                    {
                        var gObj = new GroupObject12();
                        groupObject = gObj;
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
                        if (Groups12.ContainsKey(queryName)) Groups12[queryName].Add(gObj);
                        else Groups12.Add(queryName, new List<GroupObject12> { gObj });
                    }
                    break;
                case 14:
                    {
                        var gObj = new GroupObject13();
                        groupObject = gObj;
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
                        if (Groups13.ContainsKey(queryName)) Groups13[queryName].Add(gObj);
                        else Groups13.Add(queryName, new List<GroupObject13> { gObj });
                    }
                    break;
                case 15:
                    {
                        var gObj = new GroupObject14();
                        groupObject = gObj;
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
                        if (Groups14.ContainsKey(queryName)) Groups14[queryName].Add(gObj);
                        else Groups14.Add(queryName, new List<GroupObject14> { gObj });
                    }
                    break;
                case 16:
                    {
                        var gObj = new GroupObject15();
                        groupObject = gObj;
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
                        if (Groups15.ContainsKey(queryName)) Groups15[queryName].Add(gObj);
                        else Groups15.Add(queryName, new List<GroupObject15> { gObj });
                    }
                    break;
                case 17:
                    {
                        var gObj = new GroupObject16();
                        groupObject = gObj;
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
                        if (Groups16.ContainsKey(queryName)) Groups16[queryName].Add(gObj);
                        else Groups16.Add(queryName, new List<GroupObject16> { gObj });
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
                if (component.IsInGroup(_Component))
                {
                    component.EmitSignal("tree_exited");
                }
            }
        }

        private void _EntityComponentAdded(Node newComponent, Node entity)
        {
            _EntityExitingScene(entity);
            BindToGroups(entity);
        }

        private void _EntityComponentRemoved(Node entity, Node component, GroupObject groupObject, string queryName)
        {
            entity.RemoveMeta(queryName);
            if (!Object.IsInstanceValid(groupObject)) return;
            component.RemoveFromGroup(_Component);
            switch (groupObject)
            {
                case GroupObject0 groupObject0: Groups0[queryName].Remove(groupObject0); break;
                case GroupObject1 groupObject1: Groups1[queryName].Remove(groupObject1); break;
                case GroupObject2 groupObject2: Groups2[queryName].Remove(groupObject2); break;
                case GroupObject3 groupObject3: Groups3[queryName].Remove(groupObject3); break;
                case GroupObject4 groupObject4: Groups4[queryName].Remove(groupObject4); break;
                case GroupObject5 groupObject5: Groups5[queryName].Remove(groupObject5); break;
                case GroupObject6 groupObject6: Groups6[queryName].Remove(groupObject6); break;
                case GroupObject7 groupObject7: Groups7[queryName].Remove(groupObject7); break;
                case GroupObject8 groupObject8: Groups8[queryName].Remove(groupObject8); break;
                case GroupObject9 groupObject9: Groups9[queryName].Remove(groupObject9); break;
                case GroupObject10 groupObject10: Groups10[queryName].Remove(groupObject10); break;
                case GroupObject11 groupObject11: Groups11[queryName].Remove(groupObject11); break;
                case GroupObject12 groupObject12: Groups12[queryName].Remove(groupObject12); break;
                case GroupObject13 groupObject13: Groups13[queryName].Remove(groupObject13); break;
                case GroupObject14 groupObject14: Groups14[queryName].Remove(groupObject14); break;
                case GroupObject15 groupObject15: Groups15[queryName].Remove(groupObject15); break;
                case GroupObject16 groupObject16: Groups16[queryName].Remove(groupObject16); break;
            }
            groupObject.Free();
        }

        public override void _Ready()
        {
            PostChangeScene();
        }
    }

    #region Query Class

    internal class GroupObject : Object
    {
    }

    internal class GroupObject0 : GroupObject
    {
        internal Object _obj0;
        public T Get<T>() where T : Object => _obj0 as T;
    }

    internal class GroupObject1 : GroupObject
    {
        internal Object _obj0;
        internal Object _obj1;
        public (T0, T1) Get<T0, T1>()
            where T0 : Object
            where T1 : Object
            => (_obj0 as T0, _obj1 as T1);
    }

    internal class GroupObject2 : GroupObject
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

    internal class GroupObject3 : GroupObject
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

    internal class GroupObject4 : GroupObject
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

    internal class GroupObject5 : GroupObject
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

    internal class GroupObject6 : GroupObject
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

    internal class GroupObject7 : GroupObject
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

    internal class GroupObject8 : GroupObject
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

    internal class GroupObject9 : GroupObject
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

    internal class GroupObject10 : GroupObject
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

    internal class GroupObject11 : GroupObject
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

    internal class GroupObject12 : GroupObject
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

    internal class GroupObject13 : GroupObject
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

    internal class GroupObject14 : GroupObject
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

    internal class GroupObject15 : GroupObject
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

    internal class GroupObject16 : GroupObject
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
