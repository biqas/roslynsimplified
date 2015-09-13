# roslynsimplified

Currently it is not completed. Work in progress.

```csharp
var @class = new Class("Create_Class");
@class.ToString();
```
```csharp
class Create_Class
{
}
```
```csharp
var @class = new Class("Create_Class_With_Methods")
    .AddMembers(new Field("Field_1"))
    .AddMembers(new Method(nameof(Int32), "Method_2"));
```
```csharp
class Create_Class_With_Methods
{
    Object Field_1;
    Int32 Method_2()
    {
    }
}
```


Old CodePlex Url:
[roslynsimplified](http://roslynsimplified.codeplex.com) 