EditorSculpt

お読みください＿日本語版文章
h.tomioka

<このアセットについて>
EditorSculptはUnityのエディタ上で動作するスカルプト・モデリングツールです。「Move」、「Draw」、「Inflat」、「Pinch」、「Smooth」、「Flatten」等の3Dブラシを用いてメッシュを変形させることができます。

<特色>
・自動リメッシュ/ダイナミックテッセレーションによるスカルプトモデリング
（スカルプト中にメッシュのポリゴンを、そのサイズに合わせて自動的に増加/減少させ、自動的にメッシュのトポロジーを修正します。
ただしこれはAutoRemesh Sculptだけの機能でStandard Sculptでは動作しません）

・Unityのマテリアルやシェーダをリアルタイムに表示させながらのスカルプト。

・3Dモデルのボーンをスカルプトするようにしてのアニメーション（ver1.5より）。

・スカルプト内容のブレンドシェイプでの保存（ver1.3より）。

・テクスチャの描画（ver1.1より）。

・頂点カラーの描画。

・左右対称でのモデリング。

・スカルプトしたメッシュのobjファイルでの書き出し

<始め方>
1)EditorSculptパッケージをプロジェクトにインポートすることにより、インストールされます。

2)すると、「Tools/EditorScult」メニューがUnityのエディタの「Tools」メニューに追加されます。

3)スカルプトしたいメッシュを選択してUnityのエディタのメニューから「Tools/EditorSculpt>Standard Sculpt」または「Tools/EditorSculpt>AutoRemesh Sculpt」を選びます。

 （重要！：「AutoRemesh Scult」を選んだ場合、メッシュのＵＶが破壊されます。なので、もしテクスチャが貼られたメッシュを
スカルプトしたい場合は「AutoRemesh Scult」でなく「Standard Sculpt」を選んでください）

4)すると「EditorSculpt」というウィンドウが現れますので、そのウインドゥのポップアップメニューの中から使いたいブラシを選択します。すると、スカルプトを始める用意ができます。

5）もし何もメッシュを選択せずに「EditorScult」ウィンドウを開いた場合、「Sculpt Plane」、「Sculpt Sphere」、「Sculpt Cube」ボタンが表示されます。このボタンを押すことで、プリミティブなメッシュを作成してそれをスカルプトすることが出来ます。

＜使用方法＞
スカルプト：
EditorSculptウィンドウ内の「BrushType」ポップアップメニューからブラシを選択することができます。
同じくウィンドウ内の「BrushRadius」と「Brush Strength」フィールドで、それぞれブラシの大きさと強さを調節できます。
「DisplayMode」ポップアップメニューから表示モードを選択できます。通常の表示方法だけでなく、頂点カラー、頂点ウェイトを表示させることができます。
「Symmetry」ポップアップメニューで左右対称の方向を決めます。

メッシュの編集：
EditorSculptウィンドウ内の「EditMesh」折り込みメニューを開くと、たくさんの種類の「Edit Mesh」ボタンが表示されます。それらのボタンを押すことで、メッシュを編集したり、修正したり、変形したりすることができます。

メッシュの保存：
EditorSculptウィンドウ内の「Save/Export」折り込みメニューを開くと、「Save」と「Export OBJ」ボタンが現れます。
「Save」ボタンはメッシュをUnityのアッセトとして保存します。また「Export OBJ」ボタンは.objファイルフォーマットで書き出し保存します。.objファイルには初期設定では頂点カラー情報を含んでいます。

より高度な設定：
EditorSculptウィンドウ内の「Show Advanced Options」折り込みメニューを開くと、詳細な設定を可能にするより高度なオプションが表示されます。

＜追加項目の使用方法＞
テクスチャペイント：
Unityのエディタのメニューから「Tools/EditorSculpt>Texture Paint」を選ぶかStandard Sculptの最中に「Texture Paint」ブラシを選択することによって
テクスチャペイントが開始されます。このとき、Editor Sculptウィンドウに「Texture Paint Brush Options」オプション項目が現れるので
そこで描画色を変えたり、描画するマテリアルを選択したりできます。

スカルプトしたものをBlend Shapeへと保存する：
EditorSculptウィンドウ内の「Animation」折り込みメニューの「Start Record BlendShape」ボタンを押すことで、
スカルプトの記録を開始します。
そして、そのとき「Stop Record BlendShape」ボタンを押すことでスカルプトしたものをBlendShapeへと記録できます。

アニメーション：
「Animation Move」ブラシか「Animation Tip」ブラシを選択することでアニメーションを編集することができます。
このとき、Scene Viewの画面左上に「Animation Time」スライダーが表示されます。
このスライダーを左右に動かすことでアニメーションの編集したい時間を指定することができます。
アニメーションは自動的に保存され、

アニメーションのインポート：
「Animation Move」ブラシを選択すると、Editor Sculptウィンドウに「Select Aniamtions」ポップアップメニューが現れます。
このポップアップメニューから「[Import a Aniamtion] 」項目を選択することで編集するアニメーションクリップが選択されます。
これにより、AssetDatabase内の外部のアニメーションっクリップをインポートできます。


<「AutoRemesh Sculpt」と「Standard Sculpt」の違い>
「AutoRemesh Sculpt」はスカルプト中にメッシュのポリゴンを、そのサイズに合わせて自動的に増加/減少させ、自動的にメッシュのトポロジーを修正します。それで、ポリゴンの構造を編集することなしに自由にメッシュをスカルプトすることができます。
この機能は「Autoremesh」であったり「ダイナミックテッセレーション」として知られている機能です。
「Standard Sculpt」はこの機能を持っていませんが、そのかわりメッシュのUV座標情報を保持します。
（重要！：もし、テクスチャが貼られたメッシュをスカルプトする場合、「AutoRemesh Sculpt」を使うべきではないです。
なぜなら、メッシュのＵＶを破壊してしまうからです。この場合、どうか代わりに「StandardSculpt」を使ってください。
もし、「AutoRemesh Sculpt」のこの動作でトラブルがあった場合はUnityのメニューから「Undo」を選んで
Undo操作(「Edit/Undo」) を行うことで修正することができます。)

<キーボードのショートカット>
Shift - スムーズ。滑らかにする。
Alt - ブラシの動作の反転。
Ctrl - マスクの描画。
Ctrl+Alt - マスクの消去。
Ctrl + Shift - マスクをぼかす。
Ctrl+Z - スカルプトの取り消し。
Ctrl+Y - スカルプトのやり直し。
