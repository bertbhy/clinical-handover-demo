import theme from "@chakra-ui/theme";
import { extendTheme } from "@chakra-ui/react";

const customTheme = theme;

const Textarea = {
  baseStyle: {
    background: "white",
    backgroundColor: "white",
    _focus: {
      backgroundColor: "white"
    }
  }
};
const Input = {
  parts: {
    field: "the input field itself",
    addon: "the left and right input addon"
  },
  baseStyle: {
    field: {
      bg: "white",
      _focus: {
        bg: "white"
      }
    }
  },
  variants: {
    outline: {
      field: {
        bg: "white"
      }
    },
    filled: {
      field: {
        _focus: {
          bg: "white"
        },
        _hover: {
          bg: "white"
        }
      }
    }
  },
  defaultProps: {
    size: "md",
    variant: "outline"
  }
};

const Menu = {
  baseStyle: {
    list: {
      zIndex: 81
    }
  }
};

export default extendTheme({
  components: {
    Menu,
    Textarea,
    Input
  }
});
