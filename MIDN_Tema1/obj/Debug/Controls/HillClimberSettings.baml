   M S B A M L   `   `   `  ����E  AMIDN_Tema1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MIDN_Tema1.ControlsMIDN_Tema1.Controls  5      -    'MIDN_Tema1.Controls.HillClimberSettings   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MIDN_Tema1.Controls     5      $��83.004��5      $��281.446��6/   .��5      � .+�5	   
   �� -   5          ��Name$  lblNumerOfAtempts��5	      $��Numer of Atempts:��6+   $
��Left=�6G   $	��Top=�5
      $��30��6(   �� 5   
   -   5         ��Name$ txtNumberOfAtempts��5      $��30��6.   $��	116,0,0,0q�6:    �� TextWrapping$
 Wrap=�6M   $	��Top=�5      ��5      ��  �� RelativeSource �� *FindAncestor+ �� AncestorType-   'MIDN_Tema1.Controls.HillClimberSettings"   �� Mode$ TwoWay=� �� Path$ NumberOfAtempts�5      �� 5   
   -   5        $  lblFitMethod��5      $��Fit Method:��6&   $
��Left=�6<   $��	40,41,0,0q�6W   $	��Top=�5      $��30��6(   �� 5   
   -   5         ��Name$ cmbFitMethod��5      $
��Left=�6)   $��
116,41,0,0q�6D   $	��Top=�6X   $	��165��5      $��30��6    �� DisplayMemberPath$
 Name��5   F   ��5      ��  �� *FindAncestor+"  $ 
FitMethods�5   F   5      5      