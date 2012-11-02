## Fluent-Image - Simple API to manipulate images

Authors: Alexandre Barbieri (fakeezz)

### Examples

#### Resize

```c#
FluentImage.Create("file.jpg")
           .Resize.Width(200)
           .Save("your_file.jpg");
```

#### Crop

```c#
FluentImage.Create("file.jpg")
           .Resize.Crop(new Rectangle(300, 0, 200, 900))
           .Save("your_file.jpg");
```

#### Rotate

```c#
FluentImage.Create("file.jpg")
           .Rotate.Right(90)
           .Save("your_file.jpg");
```

#### Filters

```c#
FluentImage.Create("file.jpg")
           .Filters.Add(
                Filters.Color.Sepia(),
                Filters.Hsl.Brightness(10)
           )
           .Save("your_file.jpg");
```
