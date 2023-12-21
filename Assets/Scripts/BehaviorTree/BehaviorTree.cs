using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class BehaviorTree : ScriptableObject
{
    public Node rootNode; 
    public Node.State treeState = Node.State.Running;
    public List<Node> nodes = new List<Node>();
    
    public Node.State Update()
    {
        if (treeState == Node.State.Running)
        {
            treeState = rootNode.Update();
        }
        return treeState;
    }

#if UNITY_EDITOR
    public Node CreateNode(System.Type type)
    {
        Node node = ScriptableObject.CreateInstance(type) as Node;
        node.name = type.Name;
        node.guid = GUID.Generate().ToString();

        nodes.Add(node);

        AssetDatabase.AddObjectToAsset(node, this);
        AssetDatabase.SaveAssets();

        return node;
    }

    public void DeleteNode(Node node)
    {
        nodes.Remove(node);
        AssetDatabase.RemoveObjectFromAsset(node);
        AssetDatabase.SaveAssets();
    }
#endif

    public void AddChild(Node parent, Node child)
    {
        DecoratorNode decorator = parent as DecoratorNode;
        if (decorator)
        {
            decorator.child = child;
        }
        
        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            rootNode.child = child;
        }
        
        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            composite.children.Add(child);
        }
    }
    public void RemoveChild(Node parent, Node child)
    {
        DecoratorNode decorator = parent as DecoratorNode;
        if (decorator)
        {
            decorator.child = null;
        }
        
        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            rootNode.child = null;
        }
        
        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            composite.children.Remove(child);
        }
    }
    public static List<Node> GetChildren(Node parent)
    {
        List<Node> children = new List<Node>();
        
        DecoratorNode decorator = parent as DecoratorNode;
        if (decorator && decorator.child != null)
        {
            children.Add(decorator.child);
        }
        
        RootNode rootNode = parent as RootNode;
        if (rootNode  && rootNode.child != null)
        {
            children.Add(rootNode.child);
        }
        
        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            return composite.children;
        }

        return children;
    }

    public BehaviorTree Clone()
    {
        BehaviorTree tree = Instantiate(this);
        tree.rootNode = tree.rootNode.Clone();
        return tree;
    }
    
    public static void Traverse(Node node, System.Action<Node> visiter) {
        if (node != null) {
            visiter.Invoke(node);
            var children = GetChildren(node);
            children.ForEach((n) => Traverse(n, visiter));
        }
    }
    
    public void Bind(GameObject context) {
        Traverse(rootNode, node => {
            node.context = context;
            node.OnInit();
        });
    }
}
