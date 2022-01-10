(function () {
    "use strict"; window.wsTagFilter = function module()
    {
        var $filterContainer = $(".js-tag-filter-container");
        var $filters = $(".js-tag-filter");
        var $message = $(".js-tag-filter-message");
        var $items = $(".js-tag-filter-item");
        var initialMessage = "";
        var exports = { init: function () { initialMessage = $message.text(); $filterContainer.show(); initListeners(); doFilter() } };
        function initListeners() { $filters.on("click", function (ev) { ev.preventDefault(); $(this).parent().toggleClass("active"); doFilter() }) }
        function doFilter() {
            var tags = getOnTags(); if (tags.length === 0) { $items.show() } else {
                $items.each(function (idx)
                {
                    var $item = $(this);
                    var isVisible = true; $.each(tags, function (n, tag) {
                        if ($item.hasClass(tag) === false) { isVisible = false; return false }
                    }); if (isVisible) { $item.show() } else { $item.hide() }
                })
            }
            var visibleItems = $items.filter(":visible").length;
            if (visibleItems === 0) { $message.text("No skills match the chosen filters") }
            else if (visibleItems === $items.length) { $message.text(initialMessage) }
            else { var noun = visibleItems === 1 ? "skill" : "skills"; $message.text("Showing " + visibleItems + " " + noun + " for people who like") }
        } 
        function getOnTags() {
            var tags = []; $filters.each(function (idx) {
                if ($(this).parent().hasClass("active")) {
                    var classes = $(this).parent().attr("class").split(/\s+/); $.each(classes, function (n, clss) {
                        if (clss.indexOf("js-tag-id-") === 0) { tags.push(clss) }
                    })
                }
            }); return tags
        } return exports
    };
    $(document).ready(function () { var filter = wsTagFilter(); filter.init() })
})();