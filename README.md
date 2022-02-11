# WPF-InputValidation
This repo demonstrates how to validate input and show the validation error for WPF applications.
## Introduction
With the data binding, input validation can be implemented at the source property setter, where it is called when the control element is updating the property. If the [ValidationOnExceptions](https://docs.microsoft.com/en-us/dotnet/api/system.windows.data.binding.validatesonexceptions?view=windowsdesktop-6.0) binding property is set to `true`, WPF will catch any exception thrown when updating the source property, and add it to the [Validation.Errors](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.validation.errors?view=windowsdesktop-6.0) collection.

By default, WPF will set the border of the TextBox to red when a validation error occurs, but it gives little information about the error. This project demonstrates three other methods to show the extra validation error by using the tooltip, error template and a custom control element.

![Validation error styles](./doc/images/WPF-InputValidation-0.png)

## Getting started
This project is built on .NET 6. Change the [TargetFramework](https://docs.microsoft.com/en-us/dotnet/standard/frameworks) setting in the **WPF-InputValidation.csproj** file to target other .NET versions. For example, targetting .NET 5:

`<TargetFramework>net5.0-windows</TargetFramework>`

- Run with the project in a terminal
  
  Navigate the terminal to the \src\WPF-InputValidation folder and execute command: `dotnet run`

- Open the solution (\src\WPF-InputValidation.VS2022.sln) with Visual Studio 2022.
## Pitfalls
- Binding path to the validation error

    Initially, I used `(Validation.Errors)[0].ErrorContent` as the binding path to get the validation error information. A binding error (index out of range) occurred when the `Validation.Errors` collection becomes empty after the input error has been cleared.

    The correct binding path is `(Validation.Errors)/ErrorContent`, and the binding engine will take care of the empty collection scenario.

    Thanks to the [answer](https://stackoverflow.com/questions/2260616/why-does-wpf-style-to-show-validation-errors-in-tooltip-work-for-a-textbox-but-f) at stackoverflow.

- Error template element overlapping
  
  Rendering of an adorner is independent from rendering of the UIElement that the adorner is bound to, there is no way for the TextBox to automatically adjusts its position when adorner is visible.

  ![Error template pverlapping](./doc/images/WPF-InputValidation-1.png)

    This project adds some extra margin to the TextBox when a validation error occurs to avoid the overlapping.

    However, if a custom control element is used to display the validation error, WPF will handle its posistion gracefully.

  Thanks to the [answer](https://stackoverflow.com/questions/41279151/custom-validation-error-message-overlapped-with-other-control) at stackoverflow.
## Reference
This project is inspired by this [bolg](https://kmatyaszek.github.io/wpf%20validation/2019/03/04/wpf-validation-display-errors-to-the-user.html).