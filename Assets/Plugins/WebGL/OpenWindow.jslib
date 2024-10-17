var playPlugin = {
    HTMLButtonPlugin: function()
    {
        var a = document.getElementById("play-btn");
        a.style.display = "flex";

        var b = document.getElementById("pause-btn");
        b.style.display = "flex";
        
    }
};

var URLPlugin = {
    ShowAlertPlugin: function() 
    {
        window.location.assign("https://theintellify.com");
    }
};

mergeInto(LibraryManager.library, playPlugin);
mergeInto(LibraryManager.library, URLPlugin);