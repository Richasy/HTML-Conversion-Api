# HTML Conversion Api

## What's this?

**HTML Conversion Api** provides support for export services for [Acrylic Markdown]('https://www.microsoft.com/en-us/p/acrylic-markdown/9mx0mgjmjnbj'), currently supports exporting from HTML to PDF.

Maybe you will be surprised, since I have made such a .net core project, why not deploy it on the server?

Very simple, performance issues. The converter will analyze the links contained in the HTML, the fonts referenced, and other resources, and dynamically combine them into a pdf file. This will take up a lot of system resources, and a small server in the district cannot support multiple people to request at the same time. Even with native testing, conversions are significantly slower when HTML documents contain many network resources.

So I will share this package, if you have this conversion requirement, you can deploy it yourself.

## About it

- ### Build Tool  
    .NET Core 2.2
- ### Build Platform  
    Windows 10 1809
- ### Support Platform  
    Windows  *Verified*  
    Linux  *Unverified*  
    MacOS *Unverified*
- ### Support Format  
    - pdf  

## How to use it?

> Currently only provides an interface to convert HTML to PDF

If you use the [Acrylic Markdown](https://www.microsoft.com/en-us/p/acrylic-markdown/9mx0mgjmjnbj), please [Click Here](https://blog.richasy.cn/document/acrmd/conversion.html).

### HTML -> PDF

|Route|Method|
|-|-|
|/pdf|POST|

#### Post data

```json
{
    "Title": "File Title",
    "Content": "Your Html Content"
}
```

#### Tips

- Your HTML document can be a complete web page or an HTML element.

- If you want to have a full style, then it's best to use the full HTML document structure.  
Example:  
```html
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0, user-scalable=0;">
    <title>Your title</title>
    <style>
        h1{
            color:red;
        }
    </style>
  </head>
  <body>
    <h1>Welcome!</h1>
  </body>
</html>
```
- If you want to use a custom font, no problem, but there is some trouble.  
You can put the font in the `Fonts` folder of the deployment package.But that doesn't mean you can use them directly.  
For normal introduction, you need to use the `file:///` prefix to reference its absolute path in `@font-face`.  
If you are using a web font, such as [Google Fonts](https://fonts.google.com/), you can use the `link` tag or the `@import` keyword by reference.

## Thanks

- [.Net Core](https://github.com/dotnet/core)
- [wkhtmltopdf](https://github.com/wkhtmltopdf/wkhtmltopdf)
- [DinkToPdf](https://github.com/rdvojmoc/DinkToPdf)
- [DinkToPdf Preview](https://github.com/rdvojmoc/DinkToPdf/pull/72)  
