#include "GL4D/gl4droid.h"
#include <android/asset_manager_jni.h>

typedef struct {
    const int width;
    const int height;
    const int size;
    const GLenum gl_color_format;
    const void* data;
} RawImageData;


typedef struct {
    const long data_length;
    const void* data;
    const void* file_handle;
} FileData;


FileData get_asset_data(AAssetManager*, const char* relative_path);
void release_asset_data(const FileData* file_data);

/* Returns the decoded image data, or aborts if there's an error during decoding. */
RawImageData get_raw_image_data_from_png(const void* png_data, const int png_data_size);
void release_raw_image_data(const RawImageData* data);