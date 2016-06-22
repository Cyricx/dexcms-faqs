/// <binding BeforeBuild='clean' AfterBuild='copy' />
module.exports = function (grunt) {
    //Configuration setup
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        copy: {
            domain: {
                expand: true,
                cwd: 'DexCMS.Faqs/bin/Release/',
                src: ['DexCMS.Faqs.dll'],
                dest: 'dist/'
            },
            mvc: {
                expand: true,
                cwd: 'DexCMS.Faqs.Mvc/bin/Release/',
                src: ['DexCMS.Faqs.Mvc.dll'],
                dest: 'dist/'
            },
            webapi: {
                expand: true,
                cwd: 'DexCMS.Faqs.WebApi/bin/Release/',
                src: ['DexCMS.Faqs.WebApi.dll'],
                dest: 'dist/'
            }
        },
        clean: {
            build: ["dist"]
        }
    });

    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-clean');

    grunt.registerTask('default', ['clean', 'copy']);
};
