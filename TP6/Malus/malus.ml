    let rec affiche s = function
            | 1 -> print_string (s^"0\n"); print_string (s^"1\n"); print_string (s^"2\n")
            | n -> affiche (if s = "" then "" else s^"0") (n - 1); affiche (s^"1") (n - 1); affiche (s^"2") (n - 1)
    in affiche "" 10; print_string "10000000000";;