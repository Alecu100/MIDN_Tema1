   M S B A M L   `   `   `  ����E  AMIDN_Tema1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MIDN_Tema1.ControlsMIDN_Tema1.Controls  5      2    ,MIDN_Tema1.Controls.GeneticAlgorithmSettings   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MIDN_Tema1.Controls     5      $��195.975��5      $��280.339��60   .��5      � .+�5	   
   �� -   5          ��Name$  lblMutationChance��5	      $��Mutation Chance:��6+   $
��Left=�6F   $	��Top=�6a   $��30��5
      $��4,56,0,0q�6   �� 5   
   -   5         ��Name$ txtMutationChange��5      $��30��6-   $��
112,56,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�5      ��5      ��  �� RelativeSource �� *FindAncestor+ �� AncestorType2   ,MIDN_Tema1.Controls.GeneticAlgorithmSettings"   �� Mode$ TwoWay=� �� Path$ MutationChance�5      �� 5   
   -   5        $  lblCrossoverChance��5      $��Crossover Chance:��6,   $
��Left=�6H   $��	0,107,0,0q�6c   $	��Top=�5      $��30��6(   �� 5   
   -   5        $ txtCrossoverChance��5      $��30��6.   $��112,107,0,0q�6:   $
 Wrap=�6O   $	��Top=�5      ��5      ��  �� *FindAncestor+"  $ TwoWay=�$ CrossoverChance�5      �� 5   
   -   5        $  lblCrossoverCuts��5      $��Crossover Cuts:��6*   $
��Left=�6D   $��
16,163,0,0q�6_   $	��Top=�5      $��30��6(   �� 5   
   -   5        $ txtCrossoverCuts��5      $��30��6,   $��112,163,0,0q�68   $
 Wrap=�6M   $	��Top=�5      ��5      ��  �� *FindAncestor+"  $ TwoWay=�$ CrossoverCuts�5      �� 5   
   -   5        $  lblPopulationSize��5      $��Population Size:��6+   $
��Left=�6F   $��13,0,0,0q�6a   $	��Top=�5      $��30��6(   �� 5   
   -   5        $ txtPopulationSize��5      $��30��6-   $��	112,4,0,0q�69   $
 Wrap=�6L   $	��Top=�5      ��5      ��  �� *FindAncestor+"  $ TwoWay=�$ PopulationSize�5      5       