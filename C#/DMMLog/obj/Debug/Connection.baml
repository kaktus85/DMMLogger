   M S B A M L   `   `   `  ����A  =DMMLog, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DMMLogDMMLog  5   	       DMMLog.Connection   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:DMMLog     5   	   -   5          � Title$  
Connection��5   	   $	��200��6   $	��420��6)    � 
ResizeMode$ NoResize=�65    � Icon$ multimeter-01.ico��6y   .��5	      � .+�5
   
   �� -   5         ��Name$ 	labelVISA��5
      $��VISA address or alias��6#   $
��Left=�6C   $��	10,10,0,0q�6^   $	��Top=�6q   �� 5   
   -   5         ��Name$ textBoxVISA��5      $
��Left=�6'   $��23��6B   $��
135,14,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��260��6�   �� 5   
   -   5         ��Name$ buttonConnect��5      $
��Left=�6F   $��
240,70,0,0q�6a   $	��Top=�6u   $��75��6�   ��6(   �� *	Connected+6�   �� 5   
   -   5        $ buttonClose��5      $��Close��6&   $
��Left=�66   $��
320,70,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5         ��Name$ comboBoxInstrument��5      $
��Left=�6/   $��
135,42,0,0q�6J   $	��Top=�6^   $	��260��6v    �� SelectedIndex$ 0��6�   5      �� 5   
   -   5        	 ��Name$	 textBlockIdentify��5      $��135,94,0,10q�6/   $
��Wrap=�6D   $
��Left=�6X   $	��260��6s   
 � ToolTip$&
  Response to identification query��6   �� 5   
   -   5        $ labelInstrument��5      $��
Instrument��6)   $
��Left=�6>   $��	10,40,0,0q�6Y   $	��Top=�6l   �� 5   
   -	   5        $&  comboBoxInstrumentConnectionType��5      $
��Left=�6=   $��
135,69,0,0q�6X   $	��Top=�6l   $	��100��6�   $ 0��6�   $
 Connection interface��6�   5      5      5      