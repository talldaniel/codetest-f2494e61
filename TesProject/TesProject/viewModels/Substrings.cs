using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TesProject.models;

namespace TesProject.viewModels
    {
    class Substrings : INotifyPropertyChanged
        {
        bool _isDone = true;
        int _percentDone = 0;
        int _start = 0;
        int _finish = 10000;
        int digitSumRequired = 10;
        bool _cancel = false;
        int _maxThreads = Environment.ProcessorCount;
        TimeSpan _searchTime = new TimeSpan( 0 , 0 , 0 );
        ObservableCollection<Selected> _typeNString = new ObservableCollection<Selected>( );

        double _secondsRan = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public double SecondsRan
            {
            get { return _secondsRan; }
            set
                {
                if ( value != this._secondsRan )
                    {
                    this._secondsRan = value;
                    NotifyPropertyChanged( );
                    }
                }
            }
        public Substrings()
            {
            this.FindAllTypeNStrings( );
            }
        public int MaxThreads
            {
            get { return _maxThreads; }
            set
                {
                if ( value != this._maxThreads )
                    {
                    if ( value <= 0 )
                        this.MaxThreads = 1;
                    
                    this._maxThreads = value;
                    NotifyPropertyChanged( );
                    }
                }
            }
        public bool Cancel
            {
            get { return _cancel; }
            set
                {
                if ( value != this._cancel )
                    {
                    this._cancel = value;
                    NotifyPropertyChanged( );
                    }
                }
            }

         TimeSpan SearchTime
            {
            get { return _searchTime; }
            set
                {
                if ( value != this._searchTime )
                    {
                    this._searchTime = value;
                    NotifyPropertyChanged( );
                    }
                }
            }
        public int Start
            {
            get { return _start; }
            set
                {
                if ( value != this._start )
                    {
                    this._start = value;
                    NotifyPropertyChanged( );
                    }
                }
            }

        public int Finish
            {
            get { return _finish; }
            set
                {
                if ( value != this._finish )
                    {
                    this._finish = value;
                    NotifyPropertyChanged( );
                    }
                }
            }

        public bool IsDone
            {
            get { return _isDone ; }
            set {
                if ( value != this._isDone )
                    {
                    this._isDone = value;
                    NotifyPropertyChanged( );
                    }
                }
            }
        public int PercentDone
            {
            get { return _percentDone; }
            set
                {
                if ( value != this._percentDone )
                    {
                    this._percentDone = value;
                    NotifyPropertyChanged( );
                    }
                }
            }

        public ObservableCollection<Selected> TypeNString
            {
            get { return _typeNString; }
            set
                {               
                    this._typeNString = value;
                    NotifyPropertyChanged( );
                   
                }
            }

        public async   void FindAllTypeNStrings()
            {
            this.TypeNString.Clear( );
            this.SecondsRan = 0;


            DateTime startTime = DateTime.Now;
            Predicate<string> isTypeIwant = IsTypeN;
            

            this.Cancel = false;
            ObservableCollection<Selected> local = new ObservableCollection<Selected>( );
            

            var source = Enumerable.Range( this.Start , this.Finish );
           
            //add await to this predicate
           var tried = from k in source.AsParallel( ).WithDegreeOfParallelism( MaxThreads )
                        where (  isTypeIwant( k.ToString( ) ) )
                        select new Selected
                            {
                            TheNumber = k.ToString( ) ,
                            Is10 = true

                            };

            DateTime a = DateTime.Now;

           foreach(var t in tried)
                {
                this.TypeNString.Add( t );

                }

            DateTime end = DateTime.Now;

            TimeSpan all = end - a;
            //first code
           //foreach(var j in source)
           //     {
                
           //    if(IsTypeN( j.ToString() ))
           //         {
           //         Selected next = new Selected( );
           //         next.TheNumber = j.ToString( );
           //         TypeNString.Add( next );
                    
           //         }
           //     }


            
            DateTime finish = DateTime.Now;

            TimeSpan tot =   finish - startTime;

            this.SecondsRan =   tot.TotalSeconds;

            }

         bool   IsTypeN(string val)
            {
            char [ ] myChar = val.ToCharArray( );

            int [ ]  myInt = new int [ myChar.GetUpperBound( 0 ) + 1];

            int counter = 0;

            foreach(var ch in myChar)
                {
                myInt[counter++] = int.Parse( ch.ToString() );
                }
            bool isValid = true;
            int total = 0;
             
            foreach(var c in myInt)
                {
                total += c;
                if(total>10)
                    {
                    isValid = false;
                    break;
                    }
                if(total == 10)
                    {
                    total = 0;
                    }

                }
            if(isValid == true && total == 0 )
                {
                return true;
                }

            return false;


          
            }

        private void NotifyPropertyChanged ( [CallerMemberName] String propertyName = "" )
            {
            if ( PropertyChanged != null )
                {
                PropertyChanged( this , new PropertyChangedEventArgs( propertyName ) );
                }
            }


        }
    }
