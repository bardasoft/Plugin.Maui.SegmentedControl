﻿using Plugin.Maui.SegmentedControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test.SegmentedControl;

public class MainViewModel : INotifyPropertyChanged
{
    //private readonly SegmentedControlOption[] _list1 = {
    //    new SegmentedControlOption{Text="Test0"},
    //    new SegmentedControlOption{Text="Test1"},
    //    new SegmentedControlOption{Text="Test2"}
    //};

    //internal SegmentedControlOption[] List2 = {
    //    new SegmentedControlOption{Text="Item1"},
    //    new SegmentedControlOption{Text="Item2"},
    //    new SegmentedControlOption{Text="Item3"},
    //    new SegmentedControlOption{Text="Item4"},
    //    new SegmentedControlOption{Text="Item5"}
    //};

    readonly string[] _stringSet1 = { "TestZ", "TestY" };
    readonly string[] _stringSet2 = { "TestA", "TestB", "TestC", "TestD" };

    public MainViewModel()
    {
        ChoiceText = "Start";
        ChangeText = "CHANGETEXT";
        SegmentItemsSource = new List<SegmentedControlOption>();// (_list1);
        ChangeItemsSourceCommand = new Command(OnChangeItemsSource);
        SegmentStringSource = new List<string>(_stringSet1);
        SegmentChangedCommand = new Command(OnSegmentChanged);
    }

    int changedCount;
    private void OnSegmentChanged(object obj)
    {
        changedCount++;
    }

    private void OnChangeItemsSource(object obj)
    {
        //SegmentItemsSource[0].RemoveBinding(SegmentedControlOption.TextProperty);
        //SegmentItemsSource = SegmentItemsSource.Count == list1.Length ? new List<SegmentedControlOption>(list2) : new List<SegmentedControlOption>(list1);
        //SegmentItemsSource[0].SetBinding(SegmentedControlOption.TextProperty, nameof(ChangeText));
        SegmentStringSource = SegmentStringSource.Count == _stringSet1.Length ? new List<string>(_stringSet2) : new List<string>(_stringSet1);
    }

    //private double _changeFontsize;

    //public double ChangeFontSize
    //{
    //    get => _changeFontsize;
    //    set { _changeFontsize = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(ChangeFontSize))); }
    //}

    private string _changeText;
    public string ChangeText
    {
        get => _changeText;
        set { _changeText = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(ChangeText))); }
    }

    private int _selectedSegment;
    public int SelectedSegment
    {
        get => _selectedSegment;
        set
        {
            _selectedSegment = value;
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedSegment)));
            ChoiceText = value.ToString();
        }
    }
    private IList<SegmentedControlOption> _segmentItemsSource;
    public IList<SegmentedControlOption> SegmentItemsSource
    {
        get => _segmentItemsSource;
        set { _segmentItemsSource = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(SegmentItemsSource))); }
    }

    private IList<string> _segmentStringSource;
    public IList<string> SegmentStringSource
    {
        get => _segmentStringSource;
        set { _segmentStringSource = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(SegmentStringSource))); }
    }

    private string _choiceText;
    public string ChoiceText
    {
        get => _choiceText;
        set { _choiceText = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(ChoiceText))); }
    }

    public ICommand ChangeItemsSourceCommand { get; }

    public ICommand SegmentChangedCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, e);
    }
}
