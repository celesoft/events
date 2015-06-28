﻿using System;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.UI.Xaml;
using AppBle01.Dictionary;
using AppBle01.Models;

namespace AppBle01.ViewModels.IndividualObjects
{
    /// <summary>
    /// Glue between the Characteristics View and Model.
    /// </summary>
    public class BECharacteristicVM : BeGattVmBase<GattCharacteristic>
    {
        #region ----------------- Properties -----------------
        // Funnels the model's properties to the XAML UI.
        public BeCharacteristicModel CharacteristicM { get; private set; }
        
        public string Name
        {
            get
            {
                return CharacteristicM.Name;
            }
        }

        public Guid Uuid
        {
            get
            {
                return CharacteristicM.Uuid;
            }
        }

        public string AncestorString
        {
            get
            {
                return "device: " + CharacteristicM.ServiceM.DeviceM.Name + " - " + ParentString;
            }
        }

        public string ParentString
        {
            get
            {
                return "service: " + CharacteristicM.ServiceM.Name;
            }
        }

        public string CharacteristicValue
        {
            get
            {
                return "Value: " + CharacteristicM.CharacteristicValue;
            }
        }

        public bool HexButtonChecked
        {
            get
            {
                return CharacteristicM.DisplayType == CharacteristicDictionaryEntry.ReadUnknownAsEnum.HEX;
            }
        }

        public bool IntButtonChecked
        {
            get
            {
                return CharacteristicM.DisplayType == CharacteristicDictionaryEntry.ReadUnknownAsEnum.UINT8;
            }
        }

        public bool StringButtonChecked
        {
            get
            {
                return CharacteristicM.DisplayType == CharacteristicDictionaryEntry.ReadUnknownAsEnum.STRING;
            }
        }
        
        public Visibility IsUnknownVisibility
        {
            get
            {
                if (!CharacteristicM.Default)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
        public Visibility ToastableVisibility
        {
            get
            {
                if (CharacteristicM.Toastable)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
        public string ToastRegistered
        {
            get
            {
                return "Toast Registered: " + CharacteristicM.ToastRegistered.ToString(); 
            }
        }
        public bool ToastButtonActive { get { return CharacteristicM.ToastButtonActive & GlobalSettings.BackgroundAccessRequested; } }

        public Visibility WritableVisibility
        {
            get
            {
                if (CharacteristicM.Writable)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
        public Visibility ReadableVisibility
        {
            get
            {
                if (CharacteristicM.Readable)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
        public Visibility IsParserTypeUnknownVisibility
        {
            get
            {
                if (!CharacteristicM.IsParserTypeKnown)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
        #endregion // Properties

        public void Initialize(BeCharacteristicModel characteristicM)
        {
            Model = characteristicM; 
            CharacteristicM = characteristicM;
            characteristicM.Register(this); 
        }
    }
}