var cpNavigation = require('./controlpanel.faqs.navigation'),
    cpRoutes = require('./controlpanel.faqs.routes'),
    globalSettings = require('./globals.tickets.settings.js');

module.exports = function (appPath, overrides) {
    overrides = overrides || {};
    overrides.navigation = overrides.navigation || {};

    var settings = [];
    settings.push(cpNavigation(appPath, overrides.navigation));
    settings.push(cpRoutes(appPath));
    settings.push(globalSettings(appPath));
    return settings;
};