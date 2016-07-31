module.exports = function (appPath, overrides) {
    return {
        name: 'ApplicationsControlPanelNavigation',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.navigation.json',
        options: [
            {
                "title": "Faqs",
                "icon": "fa-question-circle",
                "subLinks": [
                    {
                        "title": "Faqs",
                        "href": overrides.faqcategories || "faqcategories"
                    }
                ]
            },
        ]
    };
};