   M S B A M L   `   `   `  ���� N  JDuplicateFileFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DuplicateFileFinderDuplicateFileFinder  $    DuplicateFileFinder.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2conv!clr-namespace:DuplicateFileFinder       � Title$  Duplicate File Finder��$	��351��$	��618�� � 
ResizeMode$ CanMinimize=� � Icon$ 1411385832_18926.ico�� � 	Resources 3   -DuplicateFileFinder.BoolToVisibilityConverter   boolConverter��%   &	           � DataContext 6   0DuplicateFileFinder.DuplicateFileFinderViewModel  .��� $��0q� � RowDefinitions �� $��43 ��� .+��� 
���   �$��1q����	#80000000$��2�� K� ZIndex$ 1��y��� *IsBusy+ �� 	Converter# [  ._�� .+��� $��0q�$
��Wrap=�$��Please Wait...��$��Center=�$��Center=�$��24(�$
��Bold"����	#7EFFFFFF�� $
��Left=�$��23��$��	10,10,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��389��{�.  ���� 	 �� Path$	 
FolderPath��� $��Browse��$
��Left=�$��
404,10,0,0q�$	��Top=�$��92��$��23������ $	 FolderBrowse��� $��Find Duplicates��$
��Left=�$��
501,10,0,0q�$	��Top=�$��92��$��23������ $	 FindDuplicates�&   System.Windows.Controls.DataGrid  $��1��
   
IsReadOnly
 .    AutoGenerateColumns .  ���� *	Results+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 File�� �� *File+  $ 
SearchTerm�� �� *
SearchTerm+  $ Total�� �� *Total+4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate �� .R��� ��  �� Command �� *DataContext.OpenDuplicateFile+ �� RelativeSource �� *FindAncestor+ �� AncestorType"   �� CommandParameter �� *File+.�.��� $
��Open��