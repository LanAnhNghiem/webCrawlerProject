   M S B A M L   `   `   `  ����L  HCrawlerAndSummary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CrawlerAndSummaryCrawlerAndSummary  5   	   "    CrawlerAndSummary.HelpWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CrawlerAndSummary     5   	   Idxwui7http://schemas.devexpress.com/winfx/2008/xaml/windowsui     5   	   -   5          �Name$  HelpWindow1��5   O    � Title$ 
Quick Help��5	   	   $	��300��6   $	��500��6)   $��LeftToRight=�65   ���	#FF2F2C38 � Icon$ Resources/analysis.ico��6h    � WindowStartupLocation$ CenterScreen=�6�   .��5
      � .+�5   
   �� -   5         ��Name$ 
tabControl��5      $
��Left=�6)   $	��269��6D   $	��Top=�6Q   $	��492��6i   ��6u   Z� .@�5      �� $
��Help��6   ���	#FF8CBEBD.��5      � -   5         �Name$ 
background��5      ���	#FF413D4D$��-9,-2,-4,-6q�6B   .+�5      �� -   5         ��Name$ label��5      $-��'1. Enter the keyword you want to search��6+   $
��Left=�6]   $	��Top=�6x   $��	10,26,0,0q�6�   $��42��6�   $	��472��6�   $��20(�6�   ���	#FF8CBEBD6�   �� 5      -   5        $ 
label_Copy��5      $4��.2. List of 20 URLs will appear in the left box��60   $
��Left=�6i   $	��Top=�6�   $��	10,68,0,0q�6�   $��42��6�   $	��472��6�   $��20(�6�   ���	#FF8CBEBD6�   �� 5      -   5        $ label_Copy1��5      $"��3. Waiting for data analysis��61   $
��Left=�6X   $	��Top=�6s   $��
10,110,0,0q�6�   $��42��6�   $	��472��6�   $��20(�6�   ���	#FF8CBEBD6�   �� 5      -   5        $ label_Copy2��5      $>��84. Click          to copy all the text to your clipboard��61   $
��Left=�6t   $	��Top=�6�   $��
10,152,0,0q�6�   $��54��6�   $	��472��6�   $��20(�6�   ���	#FF8CBEBD6�   �� 5      -   5         ��Name$ image��5      $��Resources/copy.png��6+   $��39��6G   $��0,152,376,0q�6S   $	��Top=�6h    J� RenderTransformOrigin$ 0.474,0.487&�6�   $��Right=�6�   $��44��6�   5      ��5      �� 5      	 �� 
TargetType"	 ��6   .�5      �� 
 �� Property
 � �� �� Value 5      �� 5   "    �� 
TargetType" ��62   .R�5   &   � .+�5   *   �� $��Border��62   $��0,0,-4,0q�6@   $��1,1,1,0q�6R   ._�5   .   ��  ��Name$ ContentSite��6?   $��Center=�6T   $��Center=�6o   $��Header��6�   $��	12,2,12,2q�6�   ��. 6�   5   +   5   '    �� Triggers 5   &   P� 5    *    P� Property �@��
IsSelected P� Value . . �5!   .   �� 
 �@K�ZIndex$	 100��6M   �� 5"   .    �� 
TargetName$ Border��65    6_   �� *SelectedBgClr+
 � ���� 5#   .   
 � ��
 �����6K   5$   +   P� 5%   *    �@��
IsSelected .  . �5&   .   �� $ Border��65   
 � �� �	#FFFF60606_   �� 5'   .   
 � ��
 �����6K   5(   +   P� 5)   *    �@J�IsMouseOver . . �5*   .   �� $ Border��65   
 � �� �	#FF413D4D6_   �� 5+   .   
 � ��
 �����6K   5,   +   5.   #   50      51      53      �� 54      $��About Us��6   $��6,0,-6,0q�6?   ��6(   Z� .��55      � -	   5        $ background2��55      ���	#FF413D4D$��-9,-2,-4,-6q�6D   .+�56      �� -
   5        $ label_Copy3��56      $8��2Students from University Of Information Technology��61   $
��Left=�6n   $	��Top=�6�   $��	10,13,0,0q�6�   $��42��6�   $	��472��6�   $��20(�6�   ���	#FF8CBEBD6�   �� 57      -   5        $ label_Copy4��57      $"��1. Nghiem Lan Anh - 14520021��61   $
��Left=�6X   $	��Top=�6s   $��	17,55,0,0q�6�   $��42��6�   $	��472��6�   $��20(�6�   ���	#FF8CBEBD6�   �� 58      -   5        $ label_Copy5��58      $"��3. Phan Hoang Tam - 14520799��61   $
��Left=�6X   $	��Top=�6s   $��
17,139,0,0q�6�   $��42��6�   $	��472��6�   $��20(�6�   ���	#FF8CBEBD6�   �� 59      -   5        $ label_Copy6��59      $#��2. Vo Thi Thuy Nga - 14520571��61   $
��Left=�6Y   $	��Top=�6t   $��	17,97,0,0q�6�   $��42��6�   $	��472��6�   $��20(�6�   ���	#FF8CBEBD6�   �� 5:      -   5        $ label_Copy7��5:      $"��team.webcrawlerapp@gmail.com��61   $
��Left=�6X   $	��Top=�6s   $��256,181,0,0q�6�   $��42��6�   $	��233��6�   $��15(�6�   ���	#FF8CBEBD6�   5;      ��5=      �� 5>      "	 ��6   .�5?      �� 
 � �� 5@      �� 5A   "   " ��62   .R�5B   &   � .+�5C   *   �� $��Border��62   $��0,0,-4,0q�6@   $��1,1,1,0q�6R   ._�5D   .   �� $ ContentSite��6?   $��Center=�6T   $��Center=�6o   $��Header��6�   $��	12,2,12,2q�6�   ��. 6�   5E   +   5F   '    5G   &   P� 5H   *    �@��
IsSelected . . �5I   .   �� 
 �@K�ZIndex$	 100��6M   �� 5J   .   $ Border��65    6_   �� *SelectedBgClr+
 � ���� 5K   .   
 � ��
 �����6K   5L   +   P� 5M   *    �@��
IsSelected .  . �5N   .   �� $ Border��65   
 � �� �	#FFFF60606_   �� 5O   .   
 � ��
 �����6K   5P   +   P� 5Q   *    �@J�IsMouseOver . . �5R   .   �� $ Border��65   
 � �� �	#FF413D4D6_   �� 5S   .   
 � ��
 �����6K   5T   +   5V   #   5X      5Y      5[      5\      5^      5_      