module.exports = function (appPath) {
    return {
        name: 'ApplicationsControlPanelRoutes',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.routes.json',
        options: [
            {
                "name": "faqCategories",
                "module": "faqs",
                "routes": [
                {
                    "viewType": "list",
                    "path": ""
                }
                ]
            }
        ]
    };
};