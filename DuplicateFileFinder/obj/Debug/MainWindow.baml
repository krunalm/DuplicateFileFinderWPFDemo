   M S B A M L   `   `   `  ����N  JDuplicateFileFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DuplicateFileFinderDuplicateFileFinder  5   	   $    DuplicateFileFinder.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2conv!clr-namespace:DuplicateFileFinder     5   	     � Title$  Duplicate File Finder��5   	   $	��351��6'   $	��618��64    � 
ResizeMode$ CanMinimize=�6@    � Icon$ 1411385832_18926.ico��6Y    � 	Resources 5      3   -DuplicateFileFinder.BoolToVisibilityConverter   boolConverter��%   &	          5   
   6)   5       � DataContext 5	      6   0DuplicateFileFinder.DuplicateFileFinderViewModel  5
   
   .��5      � $��0q�6    � RowDefinitions 5   
   �� 5      $��43 �6   6*   �� 5      .+�5   
   �� 
���   �$��1q�6%   ���	#80000000$��2��6�    K� ZIndex$ 1��6�   y�6P   �� *IsBusy+ �� 	Converter# [  ._�5      � .+�5      �� $��0q�6   $
��Wrap=�6'   $��Please Wait...��6;   $��Center=�6Q   $��Center=�6n   $��24(�6�   $
��Bold"�6�   ���	#7EFFFFFF6�   5      5      �� 5   
   $
��Left=�6   $��23��6-   $��	10,10,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��389��6x   {�.  ��6�   �� 	 �� Path$	 
FolderPath��� 5   
   $��Browse��6   $
��Left=�6"   $��
404,10,0,0q�6=   $	��Top=�6Q   $��92��6i   $��23��6t   ��6�   �� $	 FolderBrowse��� 5   
   $��Find Duplicates��6   $
��Left=�6+   $��
501,10,0,0q�6F   $	��Top=�6Z   $��92��6r   $��23��6}   ��6�   �� $	 FindDuplicates�&   System.Windows.Controls.DataGrid  5"   
   $��1��63   
   
IsReadOnly
 .    AutoGenerateColumns .  ��6   �� *	Results+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6J     5%      $
 File��6%    63   �� *File+6N     5&      $ 
SearchTerm��6%    69   �� *
SearchTerm+6Z     5'      $ Total��6%    64   �� *Total+6P   4  .System.Windows.Controls.DataGridTemplateColumn  5(         CellTemplate 5)      �� 5*      .R�5+      �� �� 5,   "    �� Command 6,   �� *DataContext.OpenDuplicateFile+ �� RelativeSource �� *FindAncestor+ �� AncestorType"   �� CommandParameter 5.   ,   �� *File+.�6N   .�5/   '   �� $
��Open��61   50   #   51      52      54      56      57      58      