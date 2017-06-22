namespace OpenHMDNet
{
     /** Return status codes, used for all functions that can return an error. */
        public enum ohmd_status
        {
            OHMD_S_OK = 0,
            OHMD_S_UNKNOWN_ERROR = -1,
            OHMD_S_INVALID_PARAMETER = -2,

            /** OHMD_S_USER_RESERVED and below can be used for user purposes, such as errors within ohmd wrappers, etc. */
            OHMD_S_USER_RESERVED = -16384,
        }

        /** A collection of string value information types used for getting information with ohmd_list_gets(). */
        public enum ohmd_string_value
        {
            OHMD_VENDOR = 0,
            OHMD_PRODUCT = 1,
            OHMD_PATH = 2,
        }

        /** A collection of float value information types used for getting and setting information with 
         ohmd_device_getf() and ohmd_device_setf(). */
        public enum ohmd_float_value
        {
            /** float[4], get - Absolute rotation of the device, in space, as a quaternion. */
            OHMD_ROTATION_QUAT = 1,

            /** float[16], get - A "ready to use" OpenGL style 4x4 matrix with a modelview matrix for the 
             left eye of the HMD. */
            OHMD_LEFT_EYE_GL_MODELVIEW_MATRIX = 2,

            /** float[16], get - A "ready to use" OpenGL style 4x4 matrix with a modelview matrix for the 
             right eye of the HMD. */
            OHMD_RIGHT_EYE_GL_MODELVIEW_MATRIX = 3,

            /** float[16], get - A "ready to use" OpenGL style 4x4 matrix with a projection matrix for the 
             left eye of the HMD. */
            OHMD_LEFT_EYE_GL_PROJECTION_MATRIX = 4,
            /** float[16], get - A "ready to use" OpenGL style 4x4 matrix with a projection matrix for the 
             right eye of the HMD. */
            OHMD_RIGHT_EYE_GL_PROJECTION_MATRIX = 5,

            /** float[3], get - A 3-D vector representing the absolute position of the device, in space. */
            OHMD_POSITION_VECTOR = 6,

            /** float[1], get - Physical width of the device screen, in centimeters. */
            OHMD_SCREEN_HORIZONTAL_SIZE = 7,
            /** float[1], get - Physical height of the device screen, in centimeters. */
            OHMD_SCREEN_VERTICAL_SIZE = 8,

            /** float[1], get - Physical speration of the device lenses, in centimeters. */
            OHMD_LENS_HORIZONTAL_SEPARATION = 9,
            /** float[1], get - Physical vertical position of the lenses, in centimeters. */
            OHMD_LENS_VERTICAL_POSITION = 10,

            /** float[1], get - Physical field of view for the left eye, in degrees. */
            OHMD_LEFT_EYE_FOV = 11,
            /** float[1], get - Physical display aspect ratio for the left eye screen. */
            OHMD_LEFT_EYE_ASPECT_RATIO = 12,
            /** float[1], get - Physical field of view for the left right, in degrees. */
            OHMD_RIGHT_EYE_FOV = 13,
            /** float[1], get
                  Physical display aspect ratio for the right eye screen. */
            OHMD_RIGHT_EYE_ASPECT_RATIO = 14,

            /** float[1], get/set - Physical interpupilary distance of the user, in centimeters. */
            OHMD_EYE_IPD = 15,

            /** float[1], get/set - Z-far value for the projection matrix calculations, i.e. drawing distance. */
            OHMD_PROJECTION_ZFAR = 16,
            /** float[1], get/set - Z-near value for the projection matrix calculations, i.e. close clipping 
             distance. */
            OHMD_PROJECTION_ZNEAR = 17,

            /** float[6], get - Device specifc distortion value. */
            OHMD_DISTORTION_K = 18,

        }

        /** A collection of int value information types used for getting information with ohmd_device_geti()*/
        public enum ohmd_int_value
        {
            /** int[1], get
                  Physical horizontal resolution of the device screen. */
            OHMD_SCREEN_HORIZONTAL_RESOLUTION = 0,
            /** int[1], get
                  Physical vertical resolution of the device screen. */
            OHMD_SCREEN_VERTICAL_RESOLUTION = 1,

        }
}