import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { CopyToClipboard } from 'react-copy-to-clipboard';


export default class AccountShare extends Component {
    static propTypes = {
        shareUrl: PropTypes.string,
        onLinkCopy: PropTypes.func
    };

    render() {
        const shareUrl = this.props.shareUrl;
        if (!shareUrl) {
            return null;
        }

        return (
            <div>
                <p>Please save the current link to the bookmarks. This is the secret link which allows you to edit your visited countries information</p>
                <p>If you want to share your map, please use this link instead:</p>

                <div className="input-group">
                    <input type="text" className="form-control" defaultValue={shareUrl} readOnly={true} />

                    <CopyToClipboard text={shareUrl} onCopy={this.props.onLinkCopy}>
                        <span className="input-group-btn">
                            <button className="btn btn-secondary">Copy to clipboard</button>
                        </span>
                    </CopyToClipboard>
                </div>
            </div>
        );
    }
}
