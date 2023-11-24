# aspnet-pdf
exporting the binded gridview to download the PDF

## Name-Spaces Used
`using iTextSharp.text;`  `using iTextSharp.text.html.simpleparser;`  `using iTextSharp.text.pdf;`

Here a simgle binded GridView is used to downlad as PDF on a button event

## NOTE
At `HtmlTextWriter hw = new HtmlTextWriter(sw);` there would be an exception showing that the GridView must inside a form tag with runat="Server" and to bypass it we need an additional method  `VerifyRenderingInServerForm`  
the method VerifyRenderingInServerForm could be empty (without any logic), but it is used as to trap the exception and make the code run as it is
