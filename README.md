## Fluent-Image - Simple API to manipulate images

Authors: Alexandre Barbieri (fakeezz)

### Examples

#### Resize

```c#
var builder = new ImageBuilder("file.jpg");
builder.Resize.Width(200);
```

#### Crop

```c#
var builder = new ImageBuilder("file.jpg");
builder.Resize.Crop(new Rectangle(300, 0, 200, 900));
```

#### Rotate

```c#
var builder = new ImageBuilder("file.jpg");
builder.Rotate.Right(90);
```

#### Filters

```c#
var builder = new ImageBuilder("file.jpg");
builder.Filters.Add(Filters.Color.Sepia());
```
