   M S B A M L   `   `   `  ����L  HCrawlerAndSummary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CrawlerAndSummaryCrawlerAndSummary  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   "    CrawlerAndSummary.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CrawlerAndSummary     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   Edxe5http://schemas.devexpress.com/winfx/2008/xaml/editors     5   	   -   5          �Name$  MainWindow1��5   K    � Icon$ Resources/analysis.ico��6�   $	��900��5	      $	��500��6&   ���	#FF2F2C38 � WindowStartupLocation$ CenterScreen=�6g   $��
2147483644��6�   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��148* �6   �� 5      $	��75* �6   ��5   
   �� 5      .+�5   
   7  1System.Windows.Forms.Integration.WindowsFormsHost  $��20��6   $��20��6&   $��270.135,10,10,439q�62   $y�Hidden=�6M   $��1��6a      Child. 5      %  System.Windows.Forms.WebBrowser  -   5        
webBrowser��"  System.Windows.Forms.Control   Height$ 20��5   0      Margin+  %System.Windows.Forms.PaddingConverter$ 	830,0,0,0 6<      Width$ 20��6O   6Z   5      �� 5   
   -   5         ��Name$ label��5      $��	-2,0,10,0q�6   $��50��62   $��30(�6>   ���	#FFF3B562$��Center=�6c   $��Center=�6�   $	��Top=�6�   $��2��6�   $#��Vietnamese Text Summarization��6�   �� 5   
   -   5        	 ��Name$	 searchTxtBox��5      $
��Left=�6(   $��24��6C   $��	59,70,0,0q�6O   
 �� TextWrapping$

 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��250��6�   ���	#FF2F2C38
�������$��15(�6�   ���	#FF474747 �� SelectionBrush �	#FFF060606:  �� 5   
   -   5         ��Name$ 	searchBtn��5      $��Search��6$   $
��Left=�65   $��
344,69,0,0q�6P   $	��Top=�6d   $��75��6|   ���	#FFF06060
�������$��15(�6�   6�   �� 5   
   -   5        $ URLLb��5      $��URL list��6   $
��Left=�62   $��
35,109,0,0q�6M   $	��Top=�6a   ���	#FF8CBEBD$��18(�6�   �� 5   
   -   5        $ ResultLb��5      $��Result��6"   $
��Left=�63   $��424,109,0,0q�6N   $	��Top=�6c   ���	#FF8CBEBD$��18(�6�   �� 5   
   -   5         ��Name$ listBox��5      $
��Left=�6#   $	��264��6>   $��
35,158,0,0q�6K   $	��Top=�6_   $	��384��6w   
����������	#FF2F2C38���	#FF4747476�   �� 5   
   -	   5        $	 resultTxtBox��5      $
��Left=�6(   $	��264��6C   $��424,158,0,0q�6P   $

 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��424��6�   ���	#FF2F2C38
����������	#FF474747$��18(�6�    �	#FF8CBEBD �� 
IsReadOnly . $��2��6"  � 5   
   -
   5         �Name$ 
processBar��5      $��14��6*   $��35,438,44,0q�66   $	��Top=�6K   $	��813��6c   ���	#FFF06060 � Maximum$	 100Q�6�    � Value$ 0Q�6�   $��2��6�   �� 5   
   -   5        $ helpBtn��5      $��15,15,539.865,419q�6"    J� RenderTransformOrigin$ 
-0.42,0.44&�6j   ��6=   Z� ��6S   Z� .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Resources/help.png��6   $��Uniform=�64   5       5!      �� 5"   
   -   5        $ copyBtn��5"      $ 
-0.42,0.44&�6O   $��212.135,109,44,318q�6r   $��1��6�   ��6"   Z� ��68   Z� .��5#      �� $ 
Horizontal=�6   .+�5$      �� -   5         ��Name$ copyImg��5$      $��Resources/copy.png��6)   $��Uniform=�6E   $��36��6W   5%      5&      �� 5'   
   -   5        $ button��5'      $
��Edit��6!   $
��Left=�60   $��	65,16,0,0q�6K   $	��Top=�6^   $��44��6v   $ -0.431,1.145&�6�   $��32��6�   ���	#FFF06060���	#FFF7F2F26�   5)      5+      