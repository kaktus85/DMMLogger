   M S B A M L   `   `   `  ���� A  =DMMLog, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DMMLogDMMLog      DMMLog.Connection   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:DMMLog     -     � Title$  
Connection��$	��200��$	��420�� � 
ResizeMode$ NoResize=� � Icon$ multimeter-01.ico��.��� .+��� -    ��Name$ 	labelVISA��$��VISA address or alias��$
��Left=�$��	10,10,0,0q�$	��Top=��� -    ��Name$ textBoxVISA��$
��Left=�$��23��$��
135,14,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��260���� -    ��Name$ buttonConnect��$
��Left=�$��
240,70,0,0q�$	��Top=�$��75������ *	Connected+�� -   $ buttonClose��$��Close��$
��Left=�$��
320,70,0,0q�$	��Top=�$��75���� -    ��Name$ comboBoxInstrument��$
��Left=�$��
135,42,0,0q�$	��Top=�$	��260�� �� SelectedIndex$ 0���� -   	 ��Name$	 textBlockIdentify��$��135,94,0,10q�$
��Wrap=�$
��Left=�$	��260��
 � ToolTip$&
  Response to identification query���� -   $ labelInstrument��$��
Instrument��$
��Left=�$��	10,40,0,0q�$	��Top=��� -	   $&  comboBoxInstrumentConnectionType��$
��Left=�$��
135,69,0,0q�$	��Top=�$	��100��$ 0��$
 Connection interface��