# XamPctForms
## Purpose
This is an answer to the practical coding test shown in the text below.
### Xamarin – Practical Coding Test
Please review the problem below and provide a solution back to us on the specified date.
Note: there is no extra credit for a rushed solution.
Programming Problem
Provide a production ready solution that accepts a new user name, validates a single string input as the password, and
stores it locally. The solution should be written in C#/Xamarin with native UI (Android or iOS, your choice, **not Xamarin Forms**)
### UI requirements:
1. The UI should have at least a page that is a list of users and their information.
2. The UI should have the ability to add a new user, which brings up a new screen, and then appends that user to the
bottom of the list view.
3. Alert the user if their passwords are invalid either on submission or real time.
### The following are the string validations:
1. String must consist of a mixture of letters and numerical digits only, with at least one of each.
2. String must be between 5 and 12 characters in length.
3. String must not contain any sequence of characters immediately followed by the same sequence
Be sure to include all project artifacts necessary to build and run the solution.
All artifacts should be delivered in a single .zip file. Please include the .ipa or .apk files.
Thank you in advance and we look forward to seeing your work. Feel free to email us if you have any questions.
## License
A modified version of Validation was taken from eShopContainers. Ideally I would look for a NuGet package, after evaluation.

## Known Issues
Ability to delete was left unfinished.
iOS database implementation is not tested.
Prioritizing the validation error messages needs to be done.

## Possible Improvements
* An MVVM framework like Prism, MvvmLight, or MvvMCross was not used becuase navigation is quite simple.
* An IoC container is not used. Therefore mocking database interactions is not feasible.
* Dependency Service for platform-specific database paths should be tested for iOS.

## GitHub Repo 
https://github.com/blanthor/XamPctForms.git
