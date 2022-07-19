<a name='assembly'></a>
# GCore.Data.Structure.InheritedTree

## Contents

- [ChildrenChangeAction](#T-GCore-Data-Structure-InheritedTree-ChildrenChangeAction 'GCore.Data.Structure.InheritedTree.ChildrenChangeAction')
  - [Added](#F-GCore-Data-Structure-InheritedTree-ChildrenChangeAction-Added 'GCore.Data.Structure.InheritedTree.ChildrenChangeAction.Added')
  - [Removed](#F-GCore-Data-Structure-InheritedTree-ChildrenChangeAction-Removed 'GCore.Data.Structure.InheritedTree.ChildrenChangeAction.Removed')
- [ChildrenChangedEventArgs\`1](#T-GCore-Data-Structure-InheritedTree-ChildrenChangedEventArgs`1 'GCore.Data.Structure.InheritedTree.ChildrenChangedEventArgs`1')
  - [Action](#P-GCore-Data-Structure-InheritedTree-ChildrenChangedEventArgs`1-Action 'GCore.Data.Structure.InheritedTree.ChildrenChangedEventArgs`1.Action')
  - [Child](#P-GCore-Data-Structure-InheritedTree-ChildrenChangedEventArgs`1-Child 'GCore.Data.Structure.InheritedTree.ChildrenChangedEventArgs`1.Child')
- [ChildrenChangedEventHandler\`1](#T-GCore-Data-Structure-InheritedTree-ChildrenChangedEventHandler`1 'GCore.Data.Structure.InheritedTree.ChildrenChangedEventHandler`1')
- [INode\`4](#T-GCore-Data-Structure-InheritedTree-INode`4 'GCore.Data.Structure.InheritedTree.INode`4')
  - [Children](#P-GCore-Data-Structure-InheritedTree-INode`4-Children 'GCore.Data.Structure.InheritedTree.INode`4.Children')
  - [Depth](#P-GCore-Data-Structure-InheritedTree-INode`4-Depth 'GCore.Data.Structure.InheritedTree.INode`4.Depth')
  - [Item](#P-GCore-Data-Structure-InheritedTree-INode`4-Item-`2- 'GCore.Data.Structure.InheritedTree.INode`4.Item(`2)')
  - [Name](#P-GCore-Data-Structure-InheritedTree-INode`4-Name 'GCore.Data.Structure.InheritedTree.INode`4.Name')
  - [Parent](#P-GCore-Data-Structure-InheritedTree-INode`4-Parent 'GCore.Data.Structure.InheritedTree.INode`4.Parent')
  - [Path](#P-GCore-Data-Structure-InheritedTree-INode`4-Path 'GCore.Data.Structure.InheritedTree.INode`4.Path')
  - [Propertys](#P-GCore-Data-Structure-InheritedTree-INode`4-Propertys 'GCore.Data.Structure.InheritedTree.INode`4.Propertys')
  - [SelfPropertys](#P-GCore-Data-Structure-InheritedTree-INode`4-SelfPropertys 'GCore.Data.Structure.InheritedTree.INode`4.SelfPropertys')
  - [Tree](#P-GCore-Data-Structure-InheritedTree-INode`4-Tree 'GCore.Data.Structure.InheritedTree.INode`4.Tree')
  - [AddChild(child)](#M-GCore-Data-Structure-InheritedTree-INode`4-AddChild-`1- 'GCore.Data.Structure.InheritedTree.INode`4.AddChild(`1)')
  - [AddChildren(child)](#M-GCore-Data-Structure-InheritedTree-INode`4-AddChildren-System-Collections-Generic-IEnumerable{`1}- 'GCore.Data.Structure.InheritedTree.INode`4.AddChildren(System.Collections.Generic.IEnumerable{`1})')
  - [CollectPropertys(keys)](#M-GCore-Data-Structure-InheritedTree-INode`4-CollectPropertys-`2- 'GCore.Data.Structure.InheritedTree.INode`4.CollectPropertys(`2)')
  - [CreateChild(name)](#M-GCore-Data-Structure-InheritedTree-INode`4-CreateChild-System-String- 'GCore.Data.Structure.InheritedTree.INode`4.CreateChild(System.String)')
  - [CreateChild\`\`1(name)](#M-GCore-Data-Structure-InheritedTree-INode`4-CreateChild``1-System-String- 'GCore.Data.Structure.InheritedTree.INode`4.CreateChild``1(System.String)')
  - [Defines(key)](#M-GCore-Data-Structure-InheritedTree-INode`4-Defines-`2- 'GCore.Data.Structure.InheritedTree.INode`4.Defines(`2)')
  - [FindNode(path)](#M-GCore-Data-Structure-InheritedTree-INode`4-FindNode-System-String- 'GCore.Data.Structure.InheritedTree.INode`4.FindNode(System.String)')
  - [FindNode(path)](#M-GCore-Data-Structure-InheritedTree-INode`4-FindNode-System-Collections-Generic-IEnumerable{System-String}- 'GCore.Data.Structure.InheritedTree.INode`4.FindNode(System.Collections.Generic.IEnumerable{System.String})')
  - [Get(key)](#M-GCore-Data-Structure-InheritedTree-INode`4-Get-`2- 'GCore.Data.Structure.InheritedTree.INode`4.Get(`2)')
  - [GetAll()](#M-GCore-Data-Structure-InheritedTree-INode`4-GetAll 'GCore.Data.Structure.InheritedTree.INode`4.GetAll')
  - [GetChild(name)](#M-GCore-Data-Structure-InheritedTree-INode`4-GetChild-System-String- 'GCore.Data.Structure.InheritedTree.INode`4.GetChild(System.String)')
  - [GetChildren(mexDepth)](#M-GCore-Data-Structure-InheritedTree-INode`4-GetChildren-System-UInt32- 'GCore.Data.Structure.InheritedTree.INode`4.GetChildren(System.UInt32)')
  - [GetParents()](#M-GCore-Data-Structure-InheritedTree-INode`4-GetParents 'GCore.Data.Structure.InheritedTree.INode`4.GetParents')
  - [Has(key)](#M-GCore-Data-Structure-InheritedTree-INode`4-Has-`2- 'GCore.Data.Structure.InheritedTree.INode`4.Has(`2)')
  - [InitNode(nodeName,tree)](#M-GCore-Data-Structure-InheritedTree-INode`4-InitNode-System-String,`0- 'GCore.Data.Structure.InheritedTree.INode`4.InitNode(System.String,`0)')
  - [InitNode(name,tree,props,children)](#M-GCore-Data-Structure-InheritedTree-INode`4-InitNode-System-String,`0,System-Collections-Generic-IDictionary{`2,`3},System-Collections-Generic-IEnumerable{`1}- 'GCore.Data.Structure.InheritedTree.INode`4.InitNode(System.String,`0,System.Collections.Generic.IDictionary{`2,`3},System.Collections.Generic.IEnumerable{`1})')
  - [InitNode(rawNode,tree)](#M-GCore-Data-Structure-InheritedTree-INode`4-InitNode-GCore-Data-Structure-InheritedTree-RawNode{`1,`2,`3},`0- 'GCore.Data.Structure.InheritedTree.INode`4.InitNode(GCore.Data.Structure.InheritedTree.RawNode{`1,`2,`3},`0)')
  - [IsInherted(key)](#M-GCore-Data-Structure-InheritedTree-INode`4-IsInherted-`2- 'GCore.Data.Structure.InheritedTree.INode`4.IsInherted(`2)')
  - [RemoveChild(child)](#M-GCore-Data-Structure-InheritedTree-INode`4-RemoveChild-`1- 'GCore.Data.Structure.InheritedTree.INode`4.RemoveChild(`1)')
  - [RemoveParent()](#M-GCore-Data-Structure-InheritedTree-INode`4-RemoveParent 'GCore.Data.Structure.InheritedTree.INode`4.RemoveParent')
  - [ResetDefinition(key)](#M-GCore-Data-Structure-InheritedTree-INode`4-ResetDefinition-`2- 'GCore.Data.Structure.InheritedTree.INode`4.ResetDefinition(`2)')
  - [Set(key,value)](#M-GCore-Data-Structure-InheritedTree-INode`4-Set-`2,`3- 'GCore.Data.Structure.InheritedTree.INode`4.Set(`2,`3)')
  - [SetParent(parent)](#M-GCore-Data-Structure-InheritedTree-INode`4-SetParent-`1- 'GCore.Data.Structure.InheritedTree.INode`4.SetParent(`1)')
  - [ToRawNode()](#M-GCore-Data-Structure-InheritedTree-INode`4-ToRawNode 'GCore.Data.Structure.InheritedTree.INode`4.ToRawNode')
  - [UpdateOverrides()](#M-GCore-Data-Structure-InheritedTree-INode`4-UpdateOverrides 'GCore.Data.Structure.InheritedTree.INode`4.UpdateOverrides')
  - [Update\`\`1(key,args)](#M-GCore-Data-Structure-InheritedTree-INode`4-Update``1-`2,``0- 'GCore.Data.Structure.InheritedTree.INode`4.Update``1(`2,``0)')
- [INotifyChildrenChanged\`1](#T-GCore-Data-Structure-InheritedTree-INotifyChildrenChanged`1 'GCore.Data.Structure.InheritedTree.INotifyChildrenChanged`1')
- [INotifyPropertyChanged\`3](#T-GCore-Data-Structure-InheritedTree-INotifyPropertyChanged`3 'GCore.Data.Structure.InheritedTree.INotifyPropertyChanged`3')
- [IOverridingProperty\`3](#T-GCore-Data-Structure-InheritedTree-IOverridingProperty`3 'GCore.Data.Structure.InheritedTree.IOverridingProperty`3')
  - [OnOverridesProperty(property)](#M-GCore-Data-Structure-InheritedTree-IOverridingProperty`3-OnOverridesProperty-GCore-Data-Structure-InheritedTree-IProperty{`0,`1,`2}- 'GCore.Data.Structure.InheritedTree.IOverridingProperty`3.OnOverridesProperty(GCore.Data.Structure.InheritedTree.IProperty{`0,`1,`2})')
- [IProperty\`3](#T-GCore-Data-Structure-InheritedTree-IProperty`3 'GCore.Data.Structure.InheritedTree.IProperty`3')
  - [DefinedNode](#P-GCore-Data-Structure-InheritedTree-IProperty`3-DefinedNode 'GCore.Data.Structure.InheritedTree.IProperty`3.DefinedNode')
  - [Key](#P-GCore-Data-Structure-InheritedTree-IProperty`3-Key 'GCore.Data.Structure.InheritedTree.IProperty`3.Key')
  - [Value](#P-GCore-Data-Structure-InheritedTree-IProperty`3-Value 'GCore.Data.Structure.InheritedTree.IProperty`3.Value')
- [ITree\`4](#T-GCore-Data-Structure-InheritedTree-ITree`4 'GCore.Data.Structure.InheritedTree.ITree`4')
  - [RawNodeActivator](#P-GCore-Data-Structure-InheritedTree-ITree`4-RawNodeActivator 'GCore.Data.Structure.InheritedTree.ITree`4.RawNodeActivator')
  - [Root](#P-GCore-Data-Structure-InheritedTree-ITree`4-Root 'GCore.Data.Structure.InheritedTree.ITree`4.Root')
  - [Separator](#P-GCore-Data-Structure-InheritedTree-ITree`4-Separator 'GCore.Data.Structure.InheritedTree.ITree`4.Separator')
  - [CollectProperties(keys)](#M-GCore-Data-Structure-InheritedTree-ITree`4-CollectProperties-`2- 'GCore.Data.Structure.InheritedTree.ITree`4.CollectProperties(`2)')
  - [CreateNode(name)](#M-GCore-Data-Structure-InheritedTree-ITree`4-CreateNode-System-String- 'GCore.Data.Structure.InheritedTree.ITree`4.CreateNode(System.String)')
  - [CreateNode\`\`1(name)](#M-GCore-Data-Structure-InheritedTree-ITree`4-CreateNode``1-System-String- 'GCore.Data.Structure.InheritedTree.ITree`4.CreateNode``1(System.String)')
  - [FindNode(path)](#M-GCore-Data-Structure-InheritedTree-ITree`4-FindNode-System-String- 'GCore.Data.Structure.InheritedTree.ITree`4.FindNode(System.String)')
  - [UpdateOverrides()](#M-GCore-Data-Structure-InheritedTree-ITree`4-UpdateOverrides 'GCore.Data.Structure.InheritedTree.ITree`4.UpdateOverrides')
  - [Update\`\`1(key,args)](#M-GCore-Data-Structure-InheritedTree-ITree`4-Update``1-`2,``0- 'GCore.Data.Structure.InheritedTree.ITree`4.Update``1(`2,``0)')
- [IUpdatableProperty\`1](#T-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1 'GCore.Data.Structure.InheritedTree.IUpdatableProperty`1')
  - [Update(args)](#M-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1-Update-`0- 'GCore.Data.Structure.InheritedTree.IUpdatableProperty`1.Update(`0)')
- [Node\`1](#T-GCore-Data-Structure-InheritedTree-Node`1 'GCore.Data.Structure.InheritedTree.Node`1')
- [Node\`4](#T-GCore-Data-Structure-InheritedTree-Node`4 'GCore.Data.Structure.InheritedTree.Node`4')
  - [Children](#P-GCore-Data-Structure-InheritedTree-Node`4-Children 'GCore.Data.Structure.InheritedTree.Node`4.Children')
  - [Depth](#P-GCore-Data-Structure-InheritedTree-Node`4-Depth 'GCore.Data.Structure.InheritedTree.Node`4.Depth')
  - [Item](#P-GCore-Data-Structure-InheritedTree-Node`4-Item-`2- 'GCore.Data.Structure.InheritedTree.Node`4.Item(`2)')
  - [Name](#P-GCore-Data-Structure-InheritedTree-Node`4-Name 'GCore.Data.Structure.InheritedTree.Node`4.Name')
  - [Parent](#P-GCore-Data-Structure-InheritedTree-Node`4-Parent 'GCore.Data.Structure.InheritedTree.Node`4.Parent')
  - [Path](#P-GCore-Data-Structure-InheritedTree-Node`4-Path 'GCore.Data.Structure.InheritedTree.Node`4.Path')
  - [Propertys](#P-GCore-Data-Structure-InheritedTree-Node`4-Propertys 'GCore.Data.Structure.InheritedTree.Node`4.Propertys')
  - [SelfPropertys](#P-GCore-Data-Structure-InheritedTree-Node`4-SelfPropertys 'GCore.Data.Structure.InheritedTree.Node`4.SelfPropertys')
  - [Tree](#P-GCore-Data-Structure-InheritedTree-Node`4-Tree 'GCore.Data.Structure.InheritedTree.Node`4.Tree')
  - [AddChild()](#M-GCore-Data-Structure-InheritedTree-Node`4-AddChild-`1- 'GCore.Data.Structure.InheritedTree.Node`4.AddChild(`1)')
  - [AddChildren()](#M-GCore-Data-Structure-InheritedTree-Node`4-AddChildren-System-Collections-Generic-IEnumerable{`1}- 'GCore.Data.Structure.InheritedTree.Node`4.AddChildren(System.Collections.Generic.IEnumerable{`1})')
  - [CollectPropertys()](#M-GCore-Data-Structure-InheritedTree-Node`4-CollectPropertys-`2- 'GCore.Data.Structure.InheritedTree.Node`4.CollectPropertys(`2)')
  - [CreateChild()](#M-GCore-Data-Structure-InheritedTree-Node`4-CreateChild-System-String- 'GCore.Data.Structure.InheritedTree.Node`4.CreateChild(System.String)')
  - [CreateChild\`\`1()](#M-GCore-Data-Structure-InheritedTree-Node`4-CreateChild``1-System-String- 'GCore.Data.Structure.InheritedTree.Node`4.CreateChild``1(System.String)')
  - [Defines()](#M-GCore-Data-Structure-InheritedTree-Node`4-Defines-`2- 'GCore.Data.Structure.InheritedTree.Node`4.Defines(`2)')
  - [FindNode()](#M-GCore-Data-Structure-InheritedTree-Node`4-FindNode-System-String- 'GCore.Data.Structure.InheritedTree.Node`4.FindNode(System.String)')
  - [FindNode()](#M-GCore-Data-Structure-InheritedTree-Node`4-FindNode-System-Collections-Generic-IEnumerable{System-String}- 'GCore.Data.Structure.InheritedTree.Node`4.FindNode(System.Collections.Generic.IEnumerable{System.String})')
  - [Get()](#M-GCore-Data-Structure-InheritedTree-Node`4-Get-`2- 'GCore.Data.Structure.InheritedTree.Node`4.Get(`2)')
  - [GetAll()](#M-GCore-Data-Structure-InheritedTree-Node`4-GetAll 'GCore.Data.Structure.InheritedTree.Node`4.GetAll')
  - [GetChild()](#M-GCore-Data-Structure-InheritedTree-Node`4-GetChild-System-String- 'GCore.Data.Structure.InheritedTree.Node`4.GetChild(System.String)')
  - [GetChildren()](#M-GCore-Data-Structure-InheritedTree-Node`4-GetChildren-System-UInt32- 'GCore.Data.Structure.InheritedTree.Node`4.GetChildren(System.UInt32)')
  - [GetParents()](#M-GCore-Data-Structure-InheritedTree-Node`4-GetParents 'GCore.Data.Structure.InheritedTree.Node`4.GetParents')
  - [Has()](#M-GCore-Data-Structure-InheritedTree-Node`4-Has-`2- 'GCore.Data.Structure.InheritedTree.Node`4.Has(`2)')
  - [InitNode()](#M-GCore-Data-Structure-InheritedTree-Node`4-InitNode-System-String,`0- 'GCore.Data.Structure.InheritedTree.Node`4.InitNode(System.String,`0)')
  - [InitNode()](#M-GCore-Data-Structure-InheritedTree-Node`4-InitNode-System-String,`0,System-Collections-Generic-IDictionary{`2,`3},System-Collections-Generic-IEnumerable{`1}- 'GCore.Data.Structure.InheritedTree.Node`4.InitNode(System.String,`0,System.Collections.Generic.IDictionary{`2,`3},System.Collections.Generic.IEnumerable{`1})')
  - [InitNode()](#M-GCore-Data-Structure-InheritedTree-Node`4-InitNode-GCore-Data-Structure-InheritedTree-RawNode{`1,`2,`3},`0- 'GCore.Data.Structure.InheritedTree.Node`4.InitNode(GCore.Data.Structure.InheritedTree.RawNode{`1,`2,`3},`0)')
  - [IsInherted()](#M-GCore-Data-Structure-InheritedTree-Node`4-IsInherted-`2- 'GCore.Data.Structure.InheritedTree.Node`4.IsInherted(`2)')
  - [RaiseChildrenChanged()](#M-GCore-Data-Structure-InheritedTree-Node`4-RaiseChildrenChanged-GCore-Data-Structure-InheritedTree-ChildrenChangedEventArgs{`1}- 'GCore.Data.Structure.InheritedTree.Node`4.RaiseChildrenChanged(GCore.Data.Structure.InheritedTree.ChildrenChangedEventArgs{`1})')
  - [RaisePropertyChanged()](#M-GCore-Data-Structure-InheritedTree-Node`4-RaisePropertyChanged-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs{`1,`2,`3}- 'GCore.Data.Structure.InheritedTree.Node`4.RaisePropertyChanged(GCore.Data.Structure.InheritedTree.PropertyChangedEventArgs{`1,`2,`3})')
  - [RemoveChild()](#M-GCore-Data-Structure-InheritedTree-Node`4-RemoveChild-`1- 'GCore.Data.Structure.InheritedTree.Node`4.RemoveChild(`1)')
  - [ResetDefinition()](#M-GCore-Data-Structure-InheritedTree-Node`4-ResetDefinition-`2- 'GCore.Data.Structure.InheritedTree.Node`4.ResetDefinition(`2)')
  - [Set()](#M-GCore-Data-Structure-InheritedTree-Node`4-Set-`2,`3- 'GCore.Data.Structure.InheritedTree.Node`4.Set(`2,`3)')
  - [SetParent()](#M-GCore-Data-Structure-InheritedTree-Node`4-SetParent-`1- 'GCore.Data.Structure.InheritedTree.Node`4.SetParent(`1)')
  - [ToRawNode()](#M-GCore-Data-Structure-InheritedTree-Node`4-ToRawNode 'GCore.Data.Structure.InheritedTree.Node`4.ToRawNode')
  - [UpdateIOverridingProperty()](#M-GCore-Data-Structure-InheritedTree-Node`4-UpdateIOverridingProperty-`2,System-Boolean- 'GCore.Data.Structure.InheritedTree.Node`4.UpdateIOverridingProperty(`2,System.Boolean)')
  - [UpdateOverrides()](#M-GCore-Data-Structure-InheritedTree-Node`4-UpdateOverrides 'GCore.Data.Structure.InheritedTree.Node`4.UpdateOverrides')
  - [Update\`\`1()](#M-GCore-Data-Structure-InheritedTree-Node`4-Update``1-`2,``0- 'GCore.Data.Structure.InheritedTree.Node`4.Update``1(`2,``0)')
- [PropertyChangedEventArgs\`3](#T-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs`3 'GCore.Data.Structure.InheritedTree.PropertyChangedEventArgs`3')
  - [Mode](#P-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs`3-Mode 'GCore.Data.Structure.InheritedTree.PropertyChangedEventArgs`3.Mode')
  - [OldValue](#P-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs`3-OldValue 'GCore.Data.Structure.InheritedTree.PropertyChangedEventArgs`3.OldValue')
  - [Property](#P-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs`3-Property 'GCore.Data.Structure.InheritedTree.PropertyChangedEventArgs`3.Property')
- [PropertyChangedEventHandler\`3](#T-GCore-Data-Structure-InheritedTree-PropertyChangedEventHandler`3 'GCore.Data.Structure.InheritedTree.PropertyChangedEventHandler`3')
- [PropertyChangedMode](#T-GCore-Data-Structure-InheritedTree-PropertyChangedMode 'GCore.Data.Structure.InheritedTree.PropertyChangedMode')
  - [Changed](#F-GCore-Data-Structure-InheritedTree-PropertyChangedMode-Changed 'GCore.Data.Structure.InheritedTree.PropertyChangedMode.Changed')
  - [Removed](#F-GCore-Data-Structure-InheritedTree-PropertyChangedMode-Removed 'GCore.Data.Structure.InheritedTree.PropertyChangedMode.Removed')
- [Property\`3](#T-GCore-Data-Structure-InheritedTree-Property`3 'GCore.Data.Structure.InheritedTree.Property`3')
  - [DefinedNode](#P-GCore-Data-Structure-InheritedTree-Property`3-DefinedNode 'GCore.Data.Structure.InheritedTree.Property`3.DefinedNode')
  - [Key](#P-GCore-Data-Structure-InheritedTree-Property`3-Key 'GCore.Data.Structure.InheritedTree.Property`3.Key')
  - [Value](#P-GCore-Data-Structure-InheritedTree-Property`3-Value 'GCore.Data.Structure.InheritedTree.Property`3.Value')
- [RawNode\`3](#T-GCore-Data-Structure-InheritedTree-RawNode`3 'GCore.Data.Structure.InheritedTree.RawNode`3')
- [Tree\`4](#T-GCore-Data-Structure-InheritedTree-Tree`4 'GCore.Data.Structure.InheritedTree.Tree`4')
  - [RawNodeActivator](#P-GCore-Data-Structure-InheritedTree-Tree`4-RawNodeActivator 'GCore.Data.Structure.InheritedTree.Tree`4.RawNodeActivator')
  - [Root](#P-GCore-Data-Structure-InheritedTree-Tree`4-Root 'GCore.Data.Structure.InheritedTree.Tree`4.Root')
  - [Separator](#P-GCore-Data-Structure-InheritedTree-Tree`4-Separator 'GCore.Data.Structure.InheritedTree.Tree`4.Separator')
  - [CollectProperties()](#M-GCore-Data-Structure-InheritedTree-Tree`4-CollectProperties-`2- 'GCore.Data.Structure.InheritedTree.Tree`4.CollectProperties(`2)')
  - [CreateNode()](#M-GCore-Data-Structure-InheritedTree-Tree`4-CreateNode-System-String- 'GCore.Data.Structure.InheritedTree.Tree`4.CreateNode(System.String)')
  - [CreateNode\`\`1()](#M-GCore-Data-Structure-InheritedTree-Tree`4-CreateNode``1-System-String- 'GCore.Data.Structure.InheritedTree.Tree`4.CreateNode``1(System.String)')
  - [CreateNode\`\`1()](#M-GCore-Data-Structure-InheritedTree-Tree`4-CreateNode``1-System-String,System-Collections-Generic-IDictionary{`2,`3},`1[]- 'GCore.Data.Structure.InheritedTree.Tree`4.CreateNode``1(System.String,System.Collections.Generic.IDictionary{`2,`3},`1[])')
  - [FindNode()](#M-GCore-Data-Structure-InheritedTree-Tree`4-FindNode-System-String- 'GCore.Data.Structure.InheritedTree.Tree`4.FindNode(System.String)')
  - [ToRawNodes()](#M-GCore-Data-Structure-InheritedTree-Tree`4-ToRawNodes 'GCore.Data.Structure.InheritedTree.Tree`4.ToRawNodes')
  - [UpdateOverrides()](#M-GCore-Data-Structure-InheritedTree-Tree`4-UpdateOverrides 'GCore.Data.Structure.InheritedTree.Tree`4.UpdateOverrides')
  - [Update\`\`1()](#M-GCore-Data-Structure-InheritedTree-Tree`4-Update``1-`2,``0- 'GCore.Data.Structure.InheritedTree.Tree`4.Update``1(`2,``0)')

<a name='T-GCore-Data-Structure-InheritedTree-ChildrenChangeAction'></a>
## ChildrenChangeAction `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

The type of change.

<a name='F-GCore-Data-Structure-InheritedTree-ChildrenChangeAction-Added'></a>
### Added `constants`

##### Summary

Node added as child

<a name='F-GCore-Data-Structure-InheritedTree-ChildrenChangeAction-Removed'></a>
### Removed `constants`

##### Summary

Child removed

<a name='T-GCore-Data-Structure-InheritedTree-ChildrenChangedEventArgs`1'></a>
## ChildrenChangedEventArgs\`1 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Argument for [ChildrenChangedEventHandler\`1](#T-GCore-Data-Structure-InheritedTree-ChildrenChangedEventHandler`1 'GCore.Data.Structure.InheritedTree.ChildrenChangedEventHandler`1').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode | The used implementation |

<a name='P-GCore-Data-Structure-InheritedTree-ChildrenChangedEventArgs`1-Action'></a>
### Action `property`

##### Summary

The kind of change that triggered this event.

<a name='P-GCore-Data-Structure-InheritedTree-ChildrenChangedEventArgs`1-Child'></a>
### Child `property`

##### Summary

The involved child node.

<a name='T-GCore-Data-Structure-InheritedTree-ChildrenChangedEventHandler`1'></a>
## ChildrenChangedEventHandler\`1 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Delegate for the [](#E-GCore-Data-Structure-InheritedTree-Node`4-ChildrenChanged 'GCore.Data.Structure.InheritedTree.Node`4.ChildrenChanged') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:GCore.Data.Structure.InheritedTree.ChildrenChangedEventHandler\`1](#T-T-GCore-Data-Structure-InheritedTree-ChildrenChangedEventHandler`1 'T:GCore.Data.Structure.InheritedTree.ChildrenChangedEventHandler`1') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode |  |

<a name='T-GCore-Data-Structure-InheritedTree-INode`4'></a>
## INode\`4 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Represents one node of a tree.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TTree | The used implementation |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='P-GCore-Data-Structure-InheritedTree-INode`4-Children'></a>
### Children `property`

##### Summary

Direct children of this node.

<a name='P-GCore-Data-Structure-InheritedTree-INode`4-Depth'></a>
### Depth `property`

##### Summary

Distance from the root node.

<a name='P-GCore-Data-Structure-InheritedTree-INode`4-Item-`2-'></a>
### Item `property`

##### Summary

Returns the property the node has either througth inheritance of self defining.
Returns null if the property is not denined for this node.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`2](#T-`2 '`2') |  |

<a name='P-GCore-Data-Structure-InheritedTree-INode`4-Name'></a>
### Name `property`

##### Summary

The name of this node.

<a name='P-GCore-Data-Structure-InheritedTree-INode`4-Parent'></a>
### Parent `property`

##### Summary

The parent node of this node.
Null if this node is the root node.

<a name='P-GCore-Data-Structure-InheritedTree-INode`4-Path'></a>
### Path `property`

##### Summary

All names from the root to this node joined with ':'.

<a name='P-GCore-Data-Structure-InheritedTree-INode`4-Propertys'></a>
### Propertys `property`

##### Summary

All propertys this node has.
Inherited or self-defined.

<a name='P-GCore-Data-Structure-InheritedTree-INode`4-SelfPropertys'></a>
### SelfPropertys `property`

##### Summary

All propertys this node defines itfelf.

<a name='P-GCore-Data-Structure-InheritedTree-INode`4-Tree'></a>
### Tree `property`

##### Summary

The tree this node belongs to.

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-AddChild-`1-'></a>
### AddChild(child) `method`

##### Summary

Adds a new child to this node.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| child | [\`1](#T-`1 '`1') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-AddChildren-System-Collections-Generic-IEnumerable{`1}-'></a>
### AddChildren(child) `method`

##### Summary

Adds multible children to this node.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| child | [System.Collections.Generic.IEnumerable{\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`1}') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-CollectPropertys-`2-'></a>
### CollectPropertys(keys) `method`

##### Summary

Returns all propertys beween the root and this nodes in order.
Ignores if the property is overritten by a child node.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keys | [\`2](#T-`2 '`2') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-CreateChild-System-String-'></a>
### CreateChild(name) `method`

##### Summary

Creates a new node and adds it as a child.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-CreateChild``1-System-String-'></a>
### CreateChild\`\`1(name) `method`

##### Summary

Creates a new node and adds it as a child.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-Defines-`2-'></a>
### Defines(key) `method`

##### Summary

Returns true if this node (re)defines this property.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`2](#T-`2 '`2') | The property identifier |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-FindNode-System-String-'></a>
### FindNode(path) `method`

##### Summary

Find a node by its relative path.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-FindNode-System-Collections-Generic-IEnumerable{System-String}-'></a>
### FindNode(path) `method`

##### Summary

Find a node by its relative path.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-Get-`2-'></a>
### Get(key) `method`

##### Summary

Returns the property the node has either througth inheritance of self defining.
Returns null if the property is not denined for this node.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`2](#T-`2 '`2') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-GetAll'></a>
### GetAll() `method`

##### Summary

Gets all propertys this node has.
Either througth inheritance of self defining.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-GetChild-System-String-'></a>
### GetChild(name) `method`

##### Summary

Gets the child node by its name.
This is NOT recursive!

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-GetChildren-System-UInt32-'></a>
### GetChildren(mexDepth) `method`

##### Summary

Get all child nodes beneeth this node recursive.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mexDepth | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') | The maximal depth for the recursion |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-GetParents'></a>
### GetParents() `method`

##### Summary

Returns all nodes from the root node to this node (inclusive) in this order.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-Has-`2-'></a>
### Has(key) `method`

##### Summary

Returns true if this node has the defined property.
Either througth inheritance of self defining.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`2](#T-`2 '`2') | The property identifier |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-InitNode-System-String,`0-'></a>
### InitNode(nodeName,tree) `method`

##### Summary

Initializes the tree node

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nodeName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of this node |
| tree | [\`0](#T-`0 '`0') | The tree ths node belongs to |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-InitNode-System-String,`0,System-Collections-Generic-IDictionary{`2,`3},System-Collections-Generic-IEnumerable{`1}-'></a>
### InitNode(name,tree,props,children) `method`

##### Summary

Initializes the tree node

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of this node |
| tree | [\`0](#T-`0 '`0') | The tree ths node belongs to |
| props | [System.Collections.Generic.IDictionary{\`2,\`3}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IDictionary 'System.Collections.Generic.IDictionary{`2,`3}') | Pre-populate with Properties |
| children | [System.Collections.Generic.IEnumerable{\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`1}') | Pre-populate with Children |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-InitNode-GCore-Data-Structure-InheritedTree-RawNode{`1,`2,`3},`0-'></a>
### InitNode(rawNode,tree) `method`

##### Summary

Initializes the tree node

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rawNode | [GCore.Data.Structure.InheritedTree.RawNode{\`1,\`2,\`3}](#T-GCore-Data-Structure-InheritedTree-RawNode{`1,`2,`3} 'GCore.Data.Structure.InheritedTree.RawNode{`1,`2,`3}') | The serializeable node representation |
| tree | [\`0](#T-`0 '`0') | The tree ths node belongs to |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-IsInherted-`2-'></a>
### IsInherted(key) `method`

##### Summary

Returns true if the property is defined by by a parent and not
by this nodes itself.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`2](#T-`2 '`2') | The property identifier |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-RemoveChild-`1-'></a>
### RemoveChild(child) `method`

##### Summary

Removes a child from this node.

##### Returns

False if it wasn't a child of this node

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| child | [\`1](#T-`1 '`1') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-RemoveParent'></a>
### RemoveParent() `method`

##### Summary

Resets the parent node.

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-ResetDefinition-`2-'></a>
### ResetDefinition(key) `method`

##### Summary

Removes the definition of a property.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`2](#T-`2 '`2') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-Set-`2,`3-'></a>
### Set(key,value) `method`

##### Summary

(Re)Defines the property for this node.
This overrides a inherted property.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`2](#T-`2 '`2') |  |
| value | [\`3](#T-`3 '`3') |  |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-SetParent-`1-'></a>
### SetParent(parent) `method`

##### Summary

Sets the parent of this node.
Throws exception if a parent is already defined.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [\`1](#T-`1 '`1') | The new parent node |

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-ToRawNode'></a>
### ToRawNode() `method`

##### Summary

Converts the node to a serializeable RawNode

##### Returns



##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-UpdateOverrides'></a>
### UpdateOverrides() `method`

##### Summary

Spawns a update-wave for propertys implementing [IOverridingProperty\`3](#T-GCore-Data-Structure-InheritedTree-IOverridingProperty`3 'GCore.Data.Structure.InheritedTree.IOverridingProperty`3')
and invokes [](#E-GCore-Data-Structure-InheritedTree-Node`4-PropertyChanged 'GCore.Data.Structure.InheritedTree.Node`4.PropertyChanged')

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-INode`4-Update``1-`2,``0-'></a>
### Update\`\`1(key,args) `method`

##### Summary

Calls [Update](#M-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1-Update-`0- 'GCore.Data.Structure.InheritedTree.IUpdatableProperty`1.Update(`0)') on every property with this key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`2](#T-`2 '`2') | The key of the properties |
| args | [\`\`0](#T-``0 '``0') | The argument for [Update](#M-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1-Update-`0- 'GCore.Data.Structure.InheritedTree.IUpdatableProperty`1.Update(`0)') |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TArgs | Argument type for [IUpdatableProperty\`1](#T-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1 'GCore.Data.Structure.InheritedTree.IUpdatableProperty`1') |

<a name='T-GCore-Data-Structure-InheritedTree-INotifyChildrenChanged`1'></a>
## INotifyChildrenChanged\`1 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Possible trait for Node types.
Notifies the node if children changes.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode |  |
| TKey |  |
| TValue |  |

<a name='T-GCore-Data-Structure-InheritedTree-INotifyPropertyChanged`3'></a>
## INotifyPropertyChanged\`3 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Possible trait for Node types.
Notifies the node if a property changes.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='T-GCore-Data-Structure-InheritedTree-IOverridingProperty`3'></a>
## IOverridingProperty\`3 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Possible trait for property values.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='M-GCore-Data-Structure-InheritedTree-IOverridingProperty`3-OnOverridesProperty-GCore-Data-Structure-InheritedTree-IProperty{`0,`1,`2}-'></a>
### OnOverridesProperty(property) `method`

##### Summary

Gets called if the property is set.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| property | [GCore.Data.Structure.InheritedTree.IProperty{\`0,\`1,\`2}](#T-GCore-Data-Structure-InheritedTree-IProperty{`0,`1,`2} 'GCore.Data.Structure.InheritedTree.IProperty{`0,`1,`2}') | The property this property overrides. Null if there is no other property overwritten |

<a name='T-GCore-Data-Structure-InheritedTree-IProperty`3'></a>
## IProperty\`3 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

A property for [INode\`4](#T-GCore-Data-Structure-InheritedTree-INode`4 'GCore.Data.Structure.InheritedTree.INode`4').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='P-GCore-Data-Structure-InheritedTree-IProperty`3-DefinedNode'></a>
### DefinedNode `property`

##### Summary

The node this property belongs to.

<a name='P-GCore-Data-Structure-InheritedTree-IProperty`3-Key'></a>
### Key `property`

##### Summary

The identifier for this property.

<a name='P-GCore-Data-Structure-InheritedTree-IProperty`3-Value'></a>
### Value `property`

##### Summary

The value this property defines.

<a name='T-GCore-Data-Structure-InheritedTree-ITree`4'></a>
## ITree\`4 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Tree representation with inherited properties.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TTree | The used implementation |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='P-GCore-Data-Structure-InheritedTree-ITree`4-RawNodeActivator'></a>
### RawNodeActivator `property`

##### Summary

Callback to create a TNode instance from a RawNode.

<a name='P-GCore-Data-Structure-InheritedTree-ITree`4-Root'></a>
### Root `property`

##### Summary

The Root node

<a name='P-GCore-Data-Structure-InheritedTree-ITree`4-Separator'></a>
### Separator `property`

##### Summary

The string separating the node names in the path.

<a name='M-GCore-Data-Structure-InheritedTree-ITree`4-CollectProperties-`2-'></a>
### CollectProperties(keys) `method`

##### Summary

Collects all properties with the specified key inside the tree.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keys | [\`2](#T-`2 '`2') | The key of the properties. |

<a name='M-GCore-Data-Structure-InheritedTree-ITree`4-CreateNode-System-String-'></a>
### CreateNode(name) `method`

##### Summary

Create a node with this tree as origin.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of this node |

<a name='M-GCore-Data-Structure-InheritedTree-ITree`4-CreateNode``1-System-String-'></a>
### CreateNode\`\`1(name) `method`

##### Summary

Create a node with this tree as origin.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of this node |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNewNode | The type of the node |

<a name='M-GCore-Data-Structure-InheritedTree-ITree`4-FindNode-System-String-'></a>
### FindNode(path) `method`

##### Summary

Find a node by its absolute path.

##### Returns

The node found in this path

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | node names separeted by [Separator](#P-GCore-Data-Structure-InheritedTree-ITree`4-Separator 'GCore.Data.Structure.InheritedTree.ITree`4.Separator') |

<a name='M-GCore-Data-Structure-InheritedTree-ITree`4-UpdateOverrides'></a>
### UpdateOverrides() `method`

##### Summary

Spawns a update-wave for propertys implementing [IOverridingProperty\`3](#T-GCore-Data-Structure-InheritedTree-IOverridingProperty`3 'GCore.Data.Structure.InheritedTree.IOverridingProperty`3')
and invokes [](#E-GCore-Data-Structure-InheritedTree-Node`4-PropertyChanged 'GCore.Data.Structure.InheritedTree.Node`4.PropertyChanged')

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-ITree`4-Update``1-`2,``0-'></a>
### Update\`\`1(key,args) `method`

##### Summary

Calls [Update](#M-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1-Update-`0- 'GCore.Data.Structure.InheritedTree.IUpdatableProperty`1.Update(`0)') on every property with this key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`2](#T-`2 '`2') | The key of the properties |
| args | [\`\`0](#T-``0 '``0') | The argument for [Update](#M-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1-Update-`0- 'GCore.Data.Structure.InheritedTree.IUpdatableProperty`1.Update(`0)') |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TArgs | Argument type for [IUpdatableProperty\`1](#T-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1 'GCore.Data.Structure.InheritedTree.IUpdatableProperty`1') |

<a name='T-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1'></a>
## IUpdatableProperty\`1 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

A trait for the TValue of implementation.
This trait is invoked by .

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TArgs | The type of update arguments |

<a name='M-GCore-Data-Structure-InheritedTree-IUpdatableProperty`1-Update-`0-'></a>
### Update(args) `method`

##### Summary

Updates the property with the given arguments.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [\`0](#T-`0 '`0') | The arguments for the update |

<a name='T-GCore-Data-Structure-InheritedTree-Node`1'></a>
## Node\`1 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

More specified version of with as key.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TValue | The type used for the value |

<a name='T-GCore-Data-Structure-InheritedTree-Node`4'></a>
## Node\`4 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Represents one node of a tree.
Generic implamentation.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TTree | The used implementation |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='P-GCore-Data-Structure-InheritedTree-Node`4-Children'></a>
### Children `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Node`4-Depth'></a>
### Depth `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Node`4-Item-`2-'></a>
### Item `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Node`4-Name'></a>
### Name `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Node`4-Parent'></a>
### Parent `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Node`4-Path'></a>
### Path `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Node`4-Propertys'></a>
### Propertys `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Node`4-SelfPropertys'></a>
### SelfPropertys `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Node`4-Tree'></a>
### Tree `property`

##### Summary

*Inherit from parent.*

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-AddChild-`1-'></a>
### AddChild() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-AddChildren-System-Collections-Generic-IEnumerable{`1}-'></a>
### AddChildren() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-CollectPropertys-`2-'></a>
### CollectPropertys() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-CreateChild-System-String-'></a>
### CreateChild() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-CreateChild``1-System-String-'></a>
### CreateChild\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-Defines-`2-'></a>
### Defines() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-FindNode-System-String-'></a>
### FindNode() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-FindNode-System-Collections-Generic-IEnumerable{System-String}-'></a>
### FindNode() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-Get-`2-'></a>
### Get() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-GetAll'></a>
### GetAll() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-GetChild-System-String-'></a>
### GetChild() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-GetChildren-System-UInt32-'></a>
### GetChildren() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-GetParents'></a>
### GetParents() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-Has-`2-'></a>
### Has() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-InitNode-System-String,`0-'></a>
### InitNode() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-InitNode-System-String,`0,System-Collections-Generic-IDictionary{`2,`3},System-Collections-Generic-IEnumerable{`1}-'></a>
### InitNode() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-InitNode-GCore-Data-Structure-InheritedTree-RawNode{`1,`2,`3},`0-'></a>
### InitNode() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-IsInherted-`2-'></a>
### IsInherted() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-RaiseChildrenChanged-GCore-Data-Structure-InheritedTree-ChildrenChangedEventArgs{`1}-'></a>
### RaiseChildrenChanged() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-RaisePropertyChanged-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs{`1,`2,`3}-'></a>
### RaisePropertyChanged() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-RemoveChild-`1-'></a>
### RemoveChild() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-ResetDefinition-`2-'></a>
### ResetDefinition() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-Set-`2,`3-'></a>
### Set() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-SetParent-`1-'></a>
### SetParent() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-ToRawNode'></a>
### ToRawNode() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-UpdateIOverridingProperty-`2,System-Boolean-'></a>
### UpdateIOverridingProperty() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-UpdateOverrides'></a>
### UpdateOverrides() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Node`4-Update``1-`2,``0-'></a>
### Update\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs`3'></a>
## PropertyChangedEventArgs\`3 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Argument for [PropertyChangedEventHandler\`3](#T-GCore-Data-Structure-InheritedTree-PropertyChangedEventHandler`3 'GCore.Data.Structure.InheritedTree.PropertyChangedEventHandler`3').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='P-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs`3-Mode'></a>
### Mode `property`

##### Summary

The kind of change that triggered this event.

<a name='P-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs`3-OldValue'></a>
### OldValue `property`

##### Summary

The old value before the change.

<a name='P-GCore-Data-Structure-InheritedTree-PropertyChangedEventArgs`3-Property'></a>
### Property `property`

##### Summary

The property that changed.

<a name='T-GCore-Data-Structure-InheritedTree-PropertyChangedEventHandler`3'></a>
## PropertyChangedEventHandler\`3 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Delegate for the [](#E-GCore-Data-Structure-InheritedTree-Node`4-PropertyChanged 'GCore.Data.Structure.InheritedTree.Node`4.PropertyChanged') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:GCore.Data.Structure.InheritedTree.PropertyChangedEventHandler\`3](#T-T-GCore-Data-Structure-InheritedTree-PropertyChangedEventHandler`3 'T:GCore.Data.Structure.InheritedTree.PropertyChangedEventHandler`3') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='T-GCore-Data-Structure-InheritedTree-PropertyChangedMode'></a>
## PropertyChangedMode `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

The type of change.

<a name='F-GCore-Data-Structure-InheritedTree-PropertyChangedMode-Changed'></a>
### Changed `constants`

##### Summary

Property changed

<a name='F-GCore-Data-Structure-InheritedTree-PropertyChangedMode-Removed'></a>
### Removed `constants`

##### Summary

Property removed

<a name='T-GCore-Data-Structure-InheritedTree-Property`3'></a>
## Property\`3 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Default implementation of [IProperty\`3](#T-GCore-Data-Structure-InheritedTree-IProperty`3 'GCore.Data.Structure.InheritedTree.IProperty`3')

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='P-GCore-Data-Structure-InheritedTree-Property`3-DefinedNode'></a>
### DefinedNode `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Property`3-Key'></a>
### Key `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Property`3-Value'></a>
### Value `property`

##### Summary

*Inherit from parent.*

<a name='T-GCore-Data-Structure-InheritedTree-RawNode`3'></a>
## RawNode\`3 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Raw representation of a Node.
This type is used as a intermediate structure for (de)serialization.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='T-GCore-Data-Structure-InheritedTree-Tree`4'></a>
## Tree\`4 `type`

##### Namespace

GCore.Data.Structure.InheritedTree

##### Summary

Tree representation with inherited properties.
Generic implamentation.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TTree | The used implementation |
| TNode | The used implementation |
| TKey | The type used for the key |
| TValue | The type used for the value |

<a name='P-GCore-Data-Structure-InheritedTree-Tree`4-RawNodeActivator'></a>
### RawNodeActivator `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Tree`4-Root'></a>
### Root `property`

##### Summary

*Inherit from parent.*

<a name='P-GCore-Data-Structure-InheritedTree-Tree`4-Separator'></a>
### Separator `property`

##### Summary

*Inherit from parent.*

<a name='M-GCore-Data-Structure-InheritedTree-Tree`4-CollectProperties-`2-'></a>
### CollectProperties() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Tree`4-CreateNode-System-String-'></a>
### CreateNode() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Tree`4-CreateNode``1-System-String-'></a>
### CreateNode\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Tree`4-CreateNode``1-System-String,System-Collections-Generic-IDictionary{`2,`3},`1[]-'></a>
### CreateNode\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Tree`4-FindNode-System-String-'></a>
### FindNode() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Tree`4-ToRawNodes'></a>
### ToRawNodes() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Tree`4-UpdateOverrides'></a>
### UpdateOverrides() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GCore-Data-Structure-InheritedTree-Tree`4-Update``1-`2,``0-'></a>
### Update\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.
