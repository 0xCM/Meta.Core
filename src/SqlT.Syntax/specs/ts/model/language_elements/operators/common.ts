namespace operators {
    
    export type assign_op = "="

    export type add_op = "+"
    export type add_assign_op = add_op & assign_op

    export type sub_op = "-"
    export type sub_assign_op = sub_op & assign_op

    export type mul_op = "*"
    export type mul_assign_op = mul_op & assign_op

    export type div_op = "/"
    export type div_assign_op = div_op & assign_op

    export type mod_op = "%"
    export type mod_assign_op = mod_op & assign_op

    export type positive_op = "+"
    export type negative_op = "-"

    export type bw_and_op = "&"
    export type bw_and_assign_op = bw_and_op & assign_op

    export type bw_xor_op = "^"
    export type bw_xor_assign_op = bw_xor_op & assign_op

    export type bw_or_op = "|"
    export type bw_or_assign_op = bw_or_op & assign_op

    export type bw_not_op = "~"

    export type eq_op = "=";

    export type gt_op = ">"
    export type gteq_op = gt_op & eq_op

    export type lt_op = "<"
    export type lteq_op = lt_op & eq_op

    export type neq_op = "<>"
    export type nlt_op = "!<"
    export type ngt_op = "!>"
}