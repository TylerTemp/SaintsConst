# SaintsConst #

Generate const string for your Unity project of tags, layers, sortingLayers, renderingLayers.

## Usage ##

```csharp
using SaintsConst;

// use tag
gameObject.tag = TagConst.Player;

// use layer index
gameObject.layer = LayerConst.Index.Default;

// use layer mask
const int layerMask = LayerConst.Mask.Default | LayerConst.Mask.Water;

// use sorting layer
// id
GetComponent<Renderer>().sortingLayerID = SortingLayerConst.Id.New_Layer_1;
// name
GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID(SortingLayerConst.Name.New_Layer_1);

// use rendering layer
GetComponent<MeshRenderer>().renderingLayerMask = RenderingLayerConst.Mask.Light_Layer_1;
```

After editing tags/layers, the script is only updated on next script recompile/editor restart. To force to refresh it, go: `Tools/Saints Const/Refresh Saints Const`
