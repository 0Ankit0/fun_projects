/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./src/components/**/*.{js,ts,jsx,tsx,mdx}",
    "./src/app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        background: "var(--background)",
        foreground: "var(--foreground)",
        primary: {
          DEFAULT: "var(--primary)",
          light: "var(--primary-light)",
          dark: "var(--primary-dark)",
        },
        secondary: {
          DEFAULT: "var(--secondary)",
          light: "var(--secondary-light)",
          dark: "var(--secondary-dark)",
        },
        light: {
          DEFAULT: "var(--light-default)",
          light: "var(--light-light)",
          dark: "var(--light-dark)",
        },
        dark: {
          DEFAULT: "var(--dark-default)",
          light: "var(--dark-light)",
          dark: "var(--dark-dark)",
        },
        success: {
          DEFAULT: "var(--success)",
          light: "var(--success-light)",
          dark: "var(--success-dark)",
        },
        warning: {
          DEFAULT: "var(--warning)",
          light: "var(--warning-light)",
          dark: "var(--warning-dark)",
        },
        danger: {
          DEFAULT: "var(--danger)",
          light: "var(--danger-light)",
          dark: "var(--danger-dark)",
        },
      },
    },
  },
  plugins: [],
};
