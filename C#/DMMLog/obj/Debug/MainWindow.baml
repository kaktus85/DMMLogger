   M S B A M L   `   `   `  ����A  =DMMLog, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DMMLogDMMLog  5   	       DMMLog.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:DMMLog     5   	   -   5          � Title$(  "Simple logger for VISA multimeters��5   	   $	��400��64   $	��650��6A   $	��650��6M   $	��200��6\   $	��300��6l   .��5	      � .+�5
   
   o� -   5         o�Name$
 menu��5
      $��23��6   $	��Top=�6)   .@�5      m� $
��File��6   .@�5      m� -   5         m�Name$ menuItemFileNew��5      $	��New��64   6a   �� 5      6   m� 5      -   5        $ menuItemFileClose��5      $��Close��66   6g   �� 5      6   m� 5      -   5        $ menuItemExit��5      $
��Exit��61   6\   5      m� 5      -   5        $  menuItemInstrumentSettings��5      $��Instrument settings��6;   {�6X   �� *MultimeterConnected+5      m� 5      $��
Connection��6   .@�5      m� -   5        $ menuItemConnectionVISA��5      $
��VISA��6;   6p   5      m� 5      $
��Help��6   .@�5      m� -   5        $ menuItemAbout��5      $��About��62   6_   5      5      �� 5   
   -	   5         ��Name$ statusBarBottom��5      $��23��6-   $��Bottom=�69   .@�5      �� -
   5         ��Name$ statusBarLogFilePath��5      $
��Left=�6:   ��6U   �� *FilePathString+�� 5      -   5        $ statusBarConnection��5      $��Right=�69   ��6U   �� *#!ConnectedMultimeterIdentification+5      �� 5   
   -   5         ��Name$ buttonMeasure��5      $��Measure��6(   $
��Left=�6:   $	��Top=�6U   $	��120��6m   $��	10,29,0,0q�6y    � ToolTip$. (Perform the measurement sequence [Space]��6�   {�6�   �� *MultimeterConnected+6�   �� 5    
   -   5        $ buttonReset��5       $��Reset��6&   $��
550,29,0,0q�66   $	��Top=�6J   $
��Left=�6b   $��75��6}   $ Reset instrument��6�   {�6�   �� *MultimeterConnected+6�   �� 5!   
   -   5         ��Name$ listViewMeasurements��5!      $��
10,54,0,28q�61   $
��Left=�6E   $	��615��6`    �� View 5"      �� 5#      -   5        gridViewMeasurements��	 �� AllowsColumnReorder	 .  .P�5$      �� -   5        gridViewMeasurementsC1��
 �� Width$	
 150��5$   E    �� DisplayMemberBinding 6Q   �� *
Value[0]+.��5%      �� .��5&      �� -   5         ��Name$ comboBoxMode1��5&   '   $
��Left=�6>   $	��Top=�6Y   $	��145��6q   {�6}   �� *MultimeterConnected+6�   5'      5(      �� 5)      -   5        gridViewMeasurementsC2��$	
 150��5)   E    6Q   �� *
Value[1]+.��5*      �� .��5+      �� -   5        $ comboBoxMode2��5+   '   $
��Left=�6>   $	��Top=�6Y   $	��145��6q   {�6}   �� *MultimeterConnected+6�   5,      5-      �� 5.      -   5        gridViewMeasurementsC3��$	
 150��5.   E    6Q   �� *
Value[2]+.��5/      �� .��50      �� -   5        $ comboBoxMode3��50   '   $
��Left=�6>   $	��Top=�6Y   $	��145��6q   {�6}   �� *MultimeterConnected+6�   51      52      �� 53      -   5        gridViewMeasurementsC4��$	
 150��53   E    6Q   �� *
Value[3]+.��54      �� .��55      �� -   5        $ comboBoxMode4��55   '   $
��Left=�6>   $	��Top=�6Y   $	��145��6q   {�6}   �� *MultimeterConnected+6�   56      57      58       � ContextMenu 5:      �� 5;      .@�5<      m� -   5        $ 
CopyValues��5<      $��Copy selected��63   5=      m� 5>      -   5        $ CopyValuesWithHeader��5>      $��Copy selected with header��6=   5?      �� 5@      6"   m� 5A      -   5        $ Remove��5A      $��Remove selected��6/   5B      5C      5E      5G      5H      