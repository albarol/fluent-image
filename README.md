## Fluent-Image - Simple API to manipulate images

Authors: Alexandre Barbieri (fakeezz)

### Examples

#### Resize

```c#
FluentImage.FromFile("file.jpg")
           .Resize.Width(200)
           .Save("your_file.png", OutputFormat.Png);
```

#### Crop

```c#
FluentImage.FromFile("file.jpg")
           .Resize.Crop(new Rectangle(300, 0, 200, 900))
           .Save("your_file.jpg");
```

#### Rotate

```c#
FluentImage.FromFile("file.jpg")
           .Rotate.Right(90)
           .Save("your_file.jpg");
```

#### Flip

```c#
FluentImage.FromFile("file.jpg")
           .Turn.In(FlipType.Horizontal)
           .Save("your_file.jpg");
```

#### Filters

```c#
FluentImage.FromFile("file.jpg")
           .Filters.Add(
                Filters.Color.Sepia(),
                Filters.Hsl.Brightness(10)
           )
           .Save("your_file.jpg");
```
