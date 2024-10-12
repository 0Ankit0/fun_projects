/** @type {import('next').NextConfig} */
const nextConfig = {
    reactStrictMode: true,
    webpack: (config) => {
        config.resolve.alias["@"] = "./src";
        return config;
    },
    rewrites: async () => {
        const target = process.env.ASPNETCORE_HTTPS_PORT
            ? `https://localhost:${process.env.ASPNETCORE_HTTPS_PORT}`
            : process.env.ASPNETCORE_URLS?.split(";")[0] || "https://localhost:7123";

        return [
            {
                source: "/weatherforecast",
                destination: `${target}/weatherforecast`,
            },
        ];
    },
};

export default nextConfig;
