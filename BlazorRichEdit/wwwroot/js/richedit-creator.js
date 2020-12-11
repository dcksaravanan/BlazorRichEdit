var insertMacroItemId = 'insertMacroEventId';
function createRichEdit(exportUrl, documentAsBase64) {
    var newDataSource = [
        { ID: 1, Name: "Super Mart of the West", Address: "702 SW 8th Street", City: "Bentonville", Phone: "(800) 555-2797" },
        { ID: 2, Name: "Electronics Depot", Address: "2455 Paces Ferry Road NW", City: "Atlanta", Phone: "(800) 595-3232" },
        { ID: 3, Name: "K&S Music", Address: "1000 Nicllet Mall", City: "Minneapolis", Phone: "(612) 304-6073" },
        { ID: 4, Name: "Tom's Club", Address: "999 Lake Drive", City: "Issaquah", Phone: "(800) 955-2292" }
    ];
    const options = DevExpress.RichEdit.createOptions();
    options.confirmOnLosingChanges.enabled = false;
    options.exportUrl = exportUrl;
    options.width = '1400px';
    options.height = '900px';
    options.mailMerge.dataSource = newDataSource;
    options.events.customCommandExecuted = onCustomCommandExecuted;
    options.events.hyperlinkClick = onHyperLinkClicked;
    var richElement = document.getElementById("rich-container");
    const richEdit = DevExpress.RichEdit.create(richElement, options);
    if (documentAsBase64)
        richEdit.openDocument(documentAsBase64, "DocumentName", DevExpress.RichEdit.DocumentFormat.Rtf);


    onInit(richEdit);

}
function onInit(s) {
    s.contextMenu.insertItem(new DevExpress.RichEdit.ContextMenuItem(insertMacroItemId, {
        icon: 'clock', text: 'Insert Macro'
    }), 1);
}
function onHyperLinkClicked(s, e) {
    e.handled = true; console.log(e.hyperlink); console.log('Navigates to ' + e.hyperlink.hyperlinkInfo.url);
}
function onCustomCommandExecuted(s, e) {
    switch (e.commandName) {
        case insertMacroItemId:
            dotnetRef.invokeMethodAsync('ShowMacroList');
            break;
    }
}
var dotnetRef;
window.sendDotNetInstanceToJS = function (dotNetObjRef) {
    dotnetRef = dotNetObjRef;
}