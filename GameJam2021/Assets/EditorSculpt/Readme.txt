EditorSculpt

ReadMe Text

h.tomioka

<About this asset>
EditorSculpt is a sculpt modeling tool that works inside Unity editor.
You can deform mesh with 3D brush such as "Move", "Draw", "Inflat", "Pinch", "Smooth", "Flatten" or other.

<Features>
- Sculpt with Autoremesh / Dynamic tessellation(automatically increase/decrease polygons in accordance with polygon size, and automatically modifing mesh topology while sculpting -AutoRemesh Sculpt only).

- Sculpt with real-time previewing Unity's material/shader.

- Animate the model's bone as if though you sculpt that(New in ver1.5).

- Save the sculpt result to the BlendShape(New in ver1.3)

- Texture Paint(New in ver1.1)

- Vertex Color Paint.

- Symmetry Sculpting.

- Export sculpted mesh as .obj fileformat.

<How to start>
1)Import the EditorSculpt package into the project to install.

2)Now "Tools/EditorSculpt" menu item is added in Unity editor "Tools" menu.

3)Select the mesh you want to sculpt, and select "Tools/EditorSculpt>Standard Sculpt" or "Tools/EditorSculpt>AutoRemesh Scult" menu in Unity editor menu.

 (Important!: Select "AutoRemesh Sculpt" will destroy mesh UVs.
 So, if you want to sculpt textured mesh, you may not select"AutoRemesh Sculpt" but "Standard Sculpt".)

4)Then the "EditorSculpt" window will appear, and in the window's popup menu to select brush you want to use.
Now you're ready to start sculpt.

5)If  you open the "EditorSculpt" window with no mesh is selected,"Sculpt Plane" and "Sculpt Sphere" and "Sculpt Cube"buttons are appears.
Pressing these buttons, you can create primitive mesh to sculpt.

<How to use it>
Sculpt:
In the "EditorSculpt" window, you can use "BrushType" popup menu to select brush.
Also "BrushRadius" and "Brush Strength" field in the "EditorSculpt" window to control brush size and strength.
"DisplayMode"popup menu to select display mode.
you can select vertex color and vertex weight in addition to normal display mode.
"Symmetry" popoup to define symmetry axis.

Edit Mesh:
Expand "Edit Mesh" foldout in the "EditorSculpt" window to enable many kinds of "Edit Mesh" buttons.
You can edit/refine/deform mesh with pressing these buttons.

Save Mesh:
Expand "Save/Export" foldout in the "EditorSculpt" window to enable "Save" and "Export OBJ" buttons.
"Save" button to save sculpted mesh as Unity asset. and "Export" button to export ".obj"  file format.
".obj" file incldes vertex color information as default setting.

Advanced Options:
Expand "Show Advanced Options" foldout in the "EditorSculpt" window to eanable Advanced options to configuring detailed options.

<How to use additional feature>
Texture Paint:
Select "Tools/EditorSculpt>Texture Paint" menu in Unity editor menu, or select "Texture Paint" brush while standard sculpt and you can start Texture Paint.
In this time, you see "Texture Paint Brush Options" menu in the Editor Sculpt window.
With this option menu, You can change the color for paint, or Material for paint, and so on.

Save the sculpt result to the BlendShape:
You can  start record sculpting with pressing the "Start Record BlendShape" button in "Animation" foldout in the EditorSculpt Window.
In this time, You can save the sculpt result to the BlendShape with pressing the "Stop Record BlendShape" button.

Animation:
Select the "Animation Move" brush or the "Animation Tip" brush and you can start edit animations.
In this time, You see the "Animation Time" slider in the left top of the Scene View.
You can select the time of animation with changing the value of the slider.
Editor Sculpt saves the bones for animation to the animation clip automatically when you sculpt 
 and change the value of the "Animation Time" slider.
The animation clip has compatibility to Unity's Mecanim Animation System, so you can edit that animation clip with Unity's Animation tools.

Import Animation:
 You see the "Select Aniamtions" popup in the Editor Sculpt window when you select "Animation Move" brush.
 Then you can select animation clip to edit with selecting the "[Import a Aniamtion]" item in the popup.
 Then you can import existing animation clips in the AssetDatabase with the ObjectPicker.


<What is a Difference bitween "AutoRemesh Sculpt" and "Standart Sculpt">
"AutoRemesh Sculpt" automatically increase/decrease polygons in accordance with polygon size, and automatically modifing mesh topology while sculpting.
So you can sculpt meshes freely without editing polygon construction.
This feature is known as Autoremesh or Dynamic tessellation.
"Standard Sculpt" doesn't have that feature but it preserve mesh UVs insted.
(Important!: If you sculpt textured mesh, you should not use "AutoRemesh Sculpt" because it destroy mesh UVs.
In this case please use "Standard Sculpt" insted.
If you get troubled with "AutoRemesh Sculpt"'s these behaviour, 
You can fix that with "Undo" operation in the Unity menu ("Edit/Undo") .)

<Keyboad ShortCuts>
Shift - Smooth
Alt - Inverse brush behavour
Ctrl - Draw Mask
Ctrl+Alt - Erase Mask
Ctrl + Shift - Smooth Mask
Ctrl+Z - Undo Sculpt
Ctrl+Y - Redo Sculpt
