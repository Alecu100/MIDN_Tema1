   M S B A M L   `   `   `  ����E  AMIDN_Tema1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MIDN_Tema1
MIDN_Tema1  5   	       MIDN_Tema1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MIDN_Tema1     5   	     � Title$  
MainWindow��5   	   $	��603��6   $
��1399��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ cmbFunction��5
      $
��Left=�6(   $��
148,18,0,0q�6C   $	��Top=�6W   $	��155��5      $��30��6    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$
 Name��6,   ��5      ��  �� RelativeSource �� *FindAncestor+ �� AncestorType   MIDN_Tema1.MainWindow"   �� Path$ 	Functions� �� SelectedValue 5      ��  �� *FindAncestor+"   �� Mode$ TwoWay=�$ SelectedFunction��� 5   
   -   5        	 ��Name$	 lblFunction��5      $��	Function:��6%   $
��Left=�69   $��	87,18,0,0q�6T   $	��Top=�5      $��30��6(   $��61��64   �� 5   
   -   5        
 ��Name$
 txtNumberOfInputs��5      $
��Left=�6-   $��30��6H   $��
148,63,0,0q�6T    �� TextWrapping$
 Wrap=�5      $	��Top=�5      $	��155��6*   ��5      ��  �� *FindAncestor+"  $ TwoWay=�$ NumberOfInputs�5   *   �� 5   
   -   5        $	 lblNumberOfInputs��5      $��Number of Inputs:��6+   $
��Left=�6G   $��	36,63,0,0q�6b   $	��Top=�5      $��30��6(   �� 5   
   -   5        $	 lblNumberOfRuns��5      $��Number of Runs:��6)   $
��Left=�6C   $��
44,111,0,0q�6^   $	��Top=�5      $��30��6(   �� 5   
   -   5        $
 txtNumberOfRuns��5      $
��Left=�6+   $��30��6F   $��148,111,0,0q�6R   $
 Wrap=�5      $	��Top=�5      $	��155��6*    J� RenderTransformOrigin$ 
1.783,-0.7&�5      ��5      ��  �� *FindAncestor+"  $ TwoWay=�$ NumberOfRuns�5      �� 5   
   -   5         ��Name$ btnRun��5      $	��Run��6!   $
��Left=�6/   $��	84,0,0,20q�6J   $��75��5      $��30��61   $��Bottom=�6=   �� 5    
   -   5        $
 txtNumberOfIntervals��5       $
��Left=�60   $��148,161,0,0q�6K   $
 Wrap=�6`   $	��Top=�5"      $	��155��6*   $��30��66   ��5!      ��  �� *FindAncestor+"  $ TwoWay=�$ NumberOfIntervals�5"   6   �� 5#   
   -	   5        $	 lblNumberOfIntervals��5#      $��Number of Intervals:��6.   $
��Left=�6M   $��
25,161,0,0q�5$      $	��Top=�6$   $��30��6<   �� 5%   
   -
   5        $ btnClear��5%      $��Clear��6#   $
��Left=�63   $��
178,0,0,20q�6N   $��75��6b   $��30��5&   (   $��Bottom=�64   �� 5'   
   -   5         ��Name$ lstRunnerResults��5'      $��332,18,22,20q�6-   ��. $
��Auto=�5)   8   $
��Auto=�5*      ��5(      ��  �� *FindAncestor+"  $ RunnerResults� �� View 5+      �� 5,      .P�5-      �� $��Runner��6%    �� Width$ 80��6]    �� DisplayMemberBinding 65   �� *Runner+6]   �� 5.      $��
Run Number��6%   $ 90��6a    69   �� *Number+6a   �� 5/      $��Optional Field��6%   $ 90��6l   -   5        colOptionalField�� 5/   =   �� *OptionalField+50   %   �� 51      $��Function��6%   $	 140��6a    67   �� *
Function+6a   �� 52      $��Inputs��6%   $	 600��6]    65   �� *Inputs+6]   �� 53      $��Value��6%   $	 140��6[    64   �� *Value+6[   54      56      �� 57   
   -   5        $ 	cmbRunner��57      $
��Left=�6&   $��148,208,0,0q�6A   $	��Top=�6V   $	��155��58      $��30��6   $
 Name��5:      $
 Name��6,   ��59      ��  �� *FindAncestor+"  $ Runners� 5;      ��  �� *FindAncestor+"  $ TwoWay=�$ SelectedRunner�5<      �� 5=   
   -   5        $	 	lblRunner��5=      $��Runner:��6#   $
��Left=�65   $��
87,208,0,0q�6P   $	��Top=�5>      �� 5?   
   -   5         ��Name$ grpRunnerSettings��5?      $��Runner Settings��6.   $
��Left=�6G   $��10,257,0,69q�6b   $	��317��5@      .��5A      �� -   5         ��Name$ scrlViewerRunnerSettings��5A   .   $��	0,0,-2,-2q�6   $
��Auto=�6P   $
��Auto=�6u   5B      5D      5E      