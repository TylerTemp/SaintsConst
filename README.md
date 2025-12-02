# SaintsConst #

Generate const string for your Unity project of tags, layers, sortingLayers, renderingLayers.

## Usage ##

It will generate code under `Assets/SaintsConst.Generated`. Ensure you have `today.comes.saintsconst.Generated` referenced in your `asmdef`.

example:

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
GetComponent<MeshRenderer>().renderingLayerMask = RenderingLayerConst.Light_Layer_1;
```

If you edit these value in inspector, this will not get update until next domain reload. Force to refresh it using: `Window/Saints/Refresh Saints Const`

## Development ##

1.  clone this project under `Assets`
2.  `ln Editor/Editor\ Default\ Resources/SaintsConst/today.comes.saintsconst.Generated.asmdef.txt ../SaintsConst.Generated/today.comes.saintsconst.Generated.asmdef`
