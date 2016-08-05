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
                        "title": "FAQs",
                        "href": overrides.faqcategories || "faqcategories"
                    }
                ]
            },
        ]
    };
};