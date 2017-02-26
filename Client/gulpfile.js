const gulp = require('gulp');
const del = require('del');
const typescript = require('gulp-typescript');
const tscConfig = require('./tsconfig.json');
const sourcemaps = require('gulp-sourcemaps');

// clean the contents of the distribution directory
gulp.task('clean', function () {
  return del('wwwroot/**/*');
});

// copy static assets - i.e. non TypeScript compiled source
gulp.task('copy:assets', ['clean'], function() {
  console.log('copy >>> ');
  return gulp.src(['src/**/*', 'index.html', '!src/**/*.ts'], { base : './' })
    .pipe(gulp.dest('wwwroot'))
});


// TypeScript compile
gulp.task('compile', ['clean'], function () {
  return gulp
    .src(tscConfig.files)
    .pipe(sourcemaps.init())
    .pipe(typescript(tscConfig.compilerOptions))
    .pipe(sourcemaps.write('.'))
    .pipe(gulp.dest('wwwroot')); // dest: wwwroot folder
});
 
  /// Watch ??
// gulp.task('watch', ['watch.ts']);

// gulp.task('watch.ts', ['ts'], function () {
//     return gulp.watch('tsScripts/*.ts', ['ts']);
// });

gulp.task('build', ['compile', 'copy:assets']);
gulp.task('default', ['build']);