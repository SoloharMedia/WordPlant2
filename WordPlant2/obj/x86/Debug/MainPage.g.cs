﻿#pragma checksum "C:\Users\hardy\OneDrive\Documents\Visual Studio 2015\Projects\WordPlant2\WordPlant2\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EE275CC83670E75A83EFA223E23957BD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WordPlant2
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.sbMachineRunning = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 2:
                {
                    this.sbRightAnswer = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 3:
                {
                    this.sbWrongAnswer = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 4:
                {
                    this.sbRoundOver = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 5:
                {
                    this.sbGameOver = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                    #line 56 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Media.Animation.Storyboard)this.sbGameOver).Completed += this.sbGameOver_Completed;
                    #line default
                }
                break;
            case 6:
                {
                    this.sbConvayor = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 7:
                {
                    this.sbSmoke = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 8:
                {
                    this.sbBuildPress = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 9:
                {
                    this.sbBuildPressTwo = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 10:
                {
                    this.gameOverInstructions = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 11:
                {
                    this.txtRoundOver = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.theSpot = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            case 13:
                {
                    this.rectangle = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 14:
                {
                    this.machine2 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 15:
                {
                    this.machine = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 16:
                {
                    this.scoreBoard = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 17:
                {
                    this.btnBuild = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 298 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.btnBuild).Tapped += this.WordCheck;
                    #line default
                }
                break;
            case 18:
                {
                    this.btnBuild2 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 301 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.btnBuild2).Tapped += this.WordTwoCheck;
                    #line default
                }
                break;
            case 19:
                {
                    this.toggleSwitch = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                }
                break;
            case 20:
                {
                    this.musicBackground = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 21:
                {
                    this.rightAnswer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 22:
                {
                    this.wrongAnswer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 23:
                {
                    this.action = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 24:
                {
                    this.gameover = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 25:
                {
                    this.answerBar2 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 26:
                {
                    this.answerBar1 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 27:
                {
                    this.txtScore = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 28:
                {
                    this.txtCurrentLevel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 29:
                {
                    this.border = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 30:
                {
                    this.smoke = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 31:
                {
                    this.txtWasteCounter = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 32:
                {
                    this.btnGameoverNewGame = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 169 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.btnGameoverNewGame).Tapped += this.GameOverNewGame;
                    #line default
                }
                break;
            case 33:
                {
                    this.btnGameoverContinue = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 172 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.btnGameoverContinue).Tapped += this.GameOverContinue;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

