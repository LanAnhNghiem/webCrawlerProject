   M S B A M L   `   `   `  ����L  HCrawlerAndSummary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CrawlerAndSummaryCrawlerAndSummary  5   	   $    CrawlerAndSummary.Registration   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CrawlerAndSummary     5   	   -   5          �Name$  RegistrationWindow��5   	    � Title$ Registration��5   	   $	��360��6   $	��400��6+    � Icon$ Resources/analysis.ico��67   ���	#FF2F2C38 � WindowStartupLocation$ CenterScreen=�6l   .��5	      � .+�5
   
   �� -   5         ��Name$ 	groupBox1��5
      $��User's Information��6&   $
��Left=�6B   $��	10,10,0,0q�6]   $	��Top=�6p   $	��167��6�   $	��363��6�   ���	#FF474747���	#FFF06060$��0.2,0.3,0.2,0.2q�6�   $��15(�6�   .��5      �� -   5         ��Name$ lbEmail��5      $��Your email :��6%   $
��Left=�6<   $��	10,10,0,0q�6W   $	��Top=�6j   ���	#FF8CBEBD6�   5      �� 5   
   -   5        $ lbDays��5      $��Trial days :��6    $
��Left=�67   $��	27,86,0,0q�6R   $	��Top=�6e   ���	#FF8CBEBD$��15(�6�   �� 5   
   -   5         ��Name$ emailTxtBox��5      $
��Left=�6'   $��23��6B   $��
141,45,0,0q�6N   $�� ��6b   $	��Top=�6j   $	��207��6�   ���	#FF2F2C38
�������$��14(�6�   ���	#FF474747 �� MaxLines$ 1��6�    �� 	MaxLength$
 1000��6�   $��3,0,2,0q�6�   $��1��64  �� 5   
   -   5        	 ��Name$	 	getKeyBtn��5      $��Get Key��6$   $
��Left=�66   $��273,137,0,0q�6Q   $	��Top=�6f   $��75��6~   ���	#FFF06060
�������$��1��6�   �� 5   
   -   5        $ 	groupBox2��5      $��Registration��6&   $
��Left=�6<   $��
10,182,0,0q�6W   $	��Top=�6k   $	��122��6�   $	��363��6�   ���	#FF474747���	#FFF06060$��0.2,0.3,0.2,0.2q�6�   $��15(�6�   .��5      �� -   5        $ lbKey��5      $��Serial Key :��6#   $
��Left=�6:   $��	10,16,0,0q�6U   $	��Top=�6h   ���	#FF8CBEBD6�   5      �� 5   
   -	   5        $ 	keyTxtBox��5      $
��Left=�6%   $��23��6@   $��141,223,0,0q�6L   $�� ��6a   $	��Top=�6i   $	��207��6�   ���	#FF2F2C38
�������$��14(�6�   ���	#FF474747$ 1��6�   $
 1000��6�   $��4��6�   6  �� 5   
   -
   5        $	 registerBtn��5      $��Register��6&   $
��Left=�69   $��273,269,0,0q�6T   $	��Top=�6i   $��75��6�   ���	#FFF06060
�������$��5��6�   �� 5   
   -   5        $ emailLb��5      $�� ��6!   $
��Left=�6,   $��
141,64,0,0q�6G   $	��Top=�6[   ���	#FFF3B5626s   �� 5   
   -   5        $ daysLb��5      $�� ��6    $
��Left=�6+   $��141,108,0,0q�6F   $	��Top=�6[   ���	#FFF3B5626s   �� 5   
   -   5        $ 
daysTxtBox��5      $
��Left=�6&   $��23��6A   $��
141,90,0,0q�6M   $�� ��6a   $	��Top=�6i   $	��207��6�   ���	#FF2F2C38
�������$��14(�6�   ���	#FF474747$ 1��6�   $
 1000��6�   $��3,0,2,0q�6�   $��2��62  �� 5   
   -   5        $ keyLb��5      $�� ��6   $
��Left=�6*   $��141,242,0,0q�6E   $	��Top=�6Z   ���	#FFF3B5626r   5      5      