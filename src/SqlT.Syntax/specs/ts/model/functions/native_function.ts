module functions {

    export type native_function = 
        | native_window_function
        | native_scalar_function
        | native_rowset_function
}