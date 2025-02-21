using System;
using UnityEngine;

public abstract record SaveProfileData
{
    // Initializes profile's fields so not to have null values
    public void Initialize()
    {
        // get all fields
        var fields = GetType().GetFields(
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Public
        );
        // looks for classes deriving from SaveProfileData, if any initializes them
        for (int i = 0; i < fields.Length; i++)
        {
            // get the type of the field
            var fieldType = fields[i].FieldType;

            // if not a class or is abstract, interface or delegate skip
            if (!fieldType.IsClass || fieldType.IsAbstract || fieldType.IsInterface || typeof(Delegate).IsAssignableFrom(fieldType))
            {
                continue;
            }

            // if a SaveProfileData intialize it
            if (typeof(SaveProfileData).IsAssignableFrom(fieldType))
            {
                // it's a SaveProfileData, initialize it
                fields[i].SetValue
                (
                    obj: this,
                    value: Initialize
                    (
                        saveProfileData: (SaveProfileData)fields[i].GetValue(this),
                        type: fieldType
                    )
                );
            }
            else if(fieldType.GetConstructor(Type.EmptyTypes) != null)
            {
                fields[i].SetValue(this, Activator.CreateInstance(fieldType));
            }
        }
    }

    // Nested initialization, used for class fields
    public SaveProfileData Initialize(SaveProfileData saveProfileData, Type type)
    {
        // if there is nothing, create an instance of the profile through the passed Type
        if (saveProfileData == null)
            saveProfileData = (SaveProfileData)Activator.CreateInstance(type);
        else
            return saveProfileData;

        // repeat the process and check inside the new instance if there are any other class fields to be initialized
        // get all fields
        var fields = GetType().GetFields(
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Public
        );

        for (int i = 0; i < fields.Length; i++)
        {
            var fieldType = fields[i].FieldType;

            // if not a class or is abstract, interface or delegate skip
            if (!fieldType.IsClass || fieldType.IsAbstract || fieldType.IsInterface || typeof(Delegate).IsAssignableFrom(fieldType))
            {
                continue;
            }

            // if a SaveProfileData intialize it
            if (typeof(SaveProfileData).IsAssignableFrom(fieldType))
            {
                // it's a SaveProfileData, initialize it
                fields[i].SetValue
                (
                    obj: saveProfileData,
                    value: Initialize
                    (
                        saveProfileData: (SaveProfileData)fields[i].GetValue(this),
                        type: fieldType
                    )
                );
            }
            else if (fieldType.GetConstructor(Type.EmptyTypes) != null)
            {
                fields[i].SetValue(saveProfileData, Activator.CreateInstance(fieldType));
            }
        }

        return saveProfileData;
    }

    public void PrintAll()
    {
        // get all fields
        var fields = GetType().GetFields(
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Public
        );

        for (int i = 0; i < fields.Length; i++)
        {
            var fieldType = fields[i].FieldType;
            Debug.Log(fields[i].Name + " " + fields[i].GetValue(this).ToString());
            if (fields[i].GetValue(this) == null) continue;

            if (fieldType.IsClass && typeof(SaveProfileData).IsAssignableFrom(fieldType))
            {
                PrintAll
                (
                    saveProfileData: (SaveProfileData)fields[i].GetValue(this),
                    type: fieldType,
                    depth: 1
                );
            }
        }
    }

    public void PrintAll(SaveProfileData saveProfileData, Type type, int depth)
    {
        // get all fields
        var fields = saveProfileData.GetType().GetFields(
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Public
        );

        for (int i = 0; i < fields.Length; i++)
        {
            var fieldType = fields[i].FieldType;

            string depthString = string.Empty;

            for (int j = 0; j < depthString.Length; j++)
            {
                depthString += "\t";
            }

            Debug.Log(depthString + fields[i].Name + " " + fields[i].GetValue(saveProfileData));

            if (fieldType.IsClass && typeof(SaveProfileData).IsAssignableFrom(fieldType))
            {
                PrintAll
                (
                    saveProfileData: (SaveProfileData)fields[i].GetValue(saveProfileData),
                    type: fieldType,
                    depth: depth + 1
                );
            }
        }
    }

}
