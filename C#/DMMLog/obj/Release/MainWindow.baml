   M S B A M L   `   `   `  ���� A  =DMMLog, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DMMLogDMMLog      DMMLog.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:DMMLog     -     � Title$(  "Simple logger for VISA multimeters��$	��400��$	��650��$	��650��$	��200��$	��300��.��� .+�o� -    o�Name$
 menu��$��23��$	��Top=�.@�m� $
��File��.@�m� -    m�Name$ menuItemFileNew��$	��New���� m� -   $ menuItemFileClose��$��Close���� m� -   $ menuItemExit��$
��Exit��m� -   $  menuItemInstrumentSettings��$��Instrument settings��{��� *MultimeterConnected+m� $��
Connection��.@�m� -   $ menuItemConnectionVISA��$
��VISA��m� $
��Help��.@�m� -   $ menuItemAbout��$��About���� -	    ��Name$ statusBarBottom��$��23��$��Bottom=�.@��� -
    ��Name$ statusBarLogFilePath��$
��Left=����� *FilePathString+�� -   $ statusBarConnection��$��Right=����� *#!ConnectedMultimeterIdentification+�� -    ��Name$ buttonMeasure��$��Measure��$
��Left=�$	��Top=�$	��120��$��	10,29,0,0q� � ToolTip$. (Perform the measurement sequence [Space]��{��� *MultimeterConnected+�� -   $ buttonReset��$��Reset��$��
550,29,0,0q�$	��Top=�$
��Left=�$��75��$ Reset instrument��{��� *MultimeterConnected+�� -    ��Name$ listViewMeasurements��$��
10,54,0,28q�$
��Left=�$	��615�� �� View �� -   gridViewMeasurements��	 �� AllowsColumnReorder	 .  .P��� -   gridViewMeasurementsC1��
 �� Width$	
 150�� �� DisplayMemberBinding �� *
Value[0]+.���� .���� -    ��Name$ comboBoxMode1��$
��Left=�$	��Top=�$	��145��{��� *MultimeterConnected+�� -   gridViewMeasurementsC2��$	
 150�� �� *
Value[1]+.���� .���� -   $ comboBoxMode2��$
��Left=�$	��Top=�$	��145��{��� *MultimeterConnected+�� -   gridViewMeasurementsC3��$	
 150�� �� *
Value[2]+.���� .���� -   $ comboBoxMode3��$
��Left=�$	��Top=�$	��145��{��� *MultimeterConnected+�� -   gridViewMeasurementsC4��$	
 150�� �� *
Value[3]+.���� .���� -   $ comboBoxMode4��$
��Left=�$	��Top=�$	��145��{��� *MultimeterConnected+ � ContextMenu �� .@�m� -   $ 
CopyValues��$��Copy selected��m� -   $ CopyValuesWithHeader��$��Copy selected with header���� m� -   $ Remove��$��Remove selected��