/* tslint:disable */
/* eslint-disable */
/**
 * My Title
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import globalAxios, { AxiosResponse, AxiosInstance, AxiosRequestConfig } from 'axios';
import { Configuration } from '../configuration';
// Some imports not used depending on template conditions
// @ts-ignore
import { BASE_PATH, COLLECTION_FORMATS, RequestArgs, BaseAPI, RequiredError } from '../base';
/**
 * PwaApi - axios parameter creator
 * @export
 */
export const PwaApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @summary Serves the offline.html file
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        pwaOffline: async (options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/offline.html`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary Serves a service worker based on the provided settings.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        pwaServiceWorker: async (options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/serviceworker`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary Serves the manifest.json file
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        pwaWebManifest: async (options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/manifest.webmanifest`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
    }
};

/**
 * PwaApi - functional programming interface
 * @export
 */
export const PwaApiFp = function(configuration?: Configuration) {
    return {
        /**
         * 
         * @summary Serves the offline.html file
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pwaOffline(options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<string>>> {
            const localVarAxiosArgs = await PwaApiAxiosParamCreator(configuration).pwaOffline(options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary Serves a service worker based on the provided settings.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pwaServiceWorker(options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<string>>> {
            const localVarAxiosArgs = await PwaApiAxiosParamCreator(configuration).pwaServiceWorker(options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary Serves the manifest.json file
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pwaWebManifest(options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<string>>> {
            const localVarAxiosArgs = await PwaApiAxiosParamCreator(configuration).pwaWebManifest(options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
    }
};

/**
 * PwaApi - factory interface
 * @export
 */
export const PwaApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    return {
        /**
         * 
         * @summary Serves the offline.html file
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pwaOffline(options?: AxiosRequestConfig): Promise<AxiosResponse<string>> {
            return PwaApiFp(configuration).pwaOffline(options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Serves a service worker based on the provided settings.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pwaServiceWorker(options?: AxiosRequestConfig): Promise<AxiosResponse<string>> {
            return PwaApiFp(configuration).pwaServiceWorker(options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Serves the manifest.json file
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pwaWebManifest(options?: AxiosRequestConfig): Promise<AxiosResponse<string>> {
            return PwaApiFp(configuration).pwaWebManifest(options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * PwaApi - object-oriented interface
 * @export
 * @class PwaApi
 * @extends {BaseAPI}
 */
export class PwaApi extends BaseAPI {
    /**
     * 
     * @summary Serves the offline.html file
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof PwaApi
     */
    public async pwaOffline(options?: AxiosRequestConfig) : Promise<AxiosResponse<string>> {
        return PwaApiFp(this.configuration).pwaOffline(options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary Serves a service worker based on the provided settings.
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof PwaApi
     */
    public async pwaServiceWorker(options?: AxiosRequestConfig) : Promise<AxiosResponse<string>> {
        return PwaApiFp(this.configuration).pwaServiceWorker(options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary Serves the manifest.json file
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof PwaApi
     */
    public async pwaWebManifest(options?: AxiosRequestConfig) : Promise<AxiosResponse<string>> {
        return PwaApiFp(this.configuration).pwaWebManifest(options).then((request) => request(this.axios, this.basePath));
    }
}
